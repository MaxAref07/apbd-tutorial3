using apbd_app2.Domain.Models;

namespace apbd_app2.Services;

public class RentalService : IRentalService
{
    private readonly List<Rental> _rentals = new();

    public Rental RentEquipment(User user, Equipment equipment, DateTime dueDate)
    {
        if (!equipment.IsAvailable)
            throw new InvalidOperationException($"Equipment '{equipment.Name}' is not available for rental.");

        var activeCount = _rentals.Count(r => r.User.Id == user.Id && r.IsActive);
        if (activeCount >= user.MaxActiveRentals)
            throw new InvalidOperationException(
                $"User '{user.FirstName} {user.LastName}' has reached the maximum of {user.MaxActiveRentals} active rentals.");

        var rental = new Rental(user, equipment, DateTime.Now, dueDate);
        equipment.MarkAsUnavailable();
        _rentals.Add(rental);
        return rental;
    }

    public Rental ReturnEquipment(Guid rentalId, DateTime returnDate)
    {
        var rental = _rentals.FirstOrDefault(r => r.Id == rentalId)
            ?? throw new InvalidOperationException("Rental not found.");

        rental.Return(returnDate);
        rental.Equipment.MarkAsAvailable();
        return rental;
    }

    public List<Rental> GetActiveRentals(Guid userId)
    {
        return _rentals.Where(r => r.User.Id == userId && r.IsActive).ToList();
    }

    public List<Rental> GetOverdueRentals()
    {
        return _rentals.Where(r => r.IsOverdue).ToList();
    }

    public string GenerateReport()
    {
        var total = _rentals.Count;
        var active = _rentals.Count(r => r.IsActive);
        var overdue = _rentals.Count(r => r.IsOverdue);
        var returned = _rentals.Count(r => !r.IsActive);
        var totalPenalties = _rentals.Sum(r => r.Penalty);

        return 
            $"""
            Total rentals:      {total}
            Active rentals:     {active}
            Overdue rentals:    {overdue}
            Completed returns:  {returned}
            Total penalties:    {totalPenalties:C}
            """;
    }
}