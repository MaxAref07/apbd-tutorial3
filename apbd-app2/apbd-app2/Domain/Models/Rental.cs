using Ardalis.GuardClauses;

namespace apbd_app2.Domain.Models;

public class Rental
{
    public Guid Id { get; init; }
    public User User { get; init; }
    public Equipment Equipment { get; init; }
    public DateTime RentalDate { get; init; }
    public DateTime DueDate { get; init; }
    public DateTime? ActualReturnDate { get; private set; }
    public decimal Penalty { get; private set; }

    private const decimal PenaltyPerDay = 10.0m;

    public Rental(User user, Equipment equipment, DateTime rentalDate, DateTime dueDate)
    {
        Guard.Against.Null(user, nameof(user));
        Guard.Against.Null(equipment, nameof(equipment));

        if (dueDate <= rentalDate)
            throw new ArgumentException("Due date can not be earlier than rental date");

        Id = Guid.NewGuid();
        User = user;
        Equipment = equipment;
        RentalDate = rentalDate;
        DueDate = dueDate;
        Penalty = 0;
    }

    public bool IsActive => ActualReturnDate == null;

    public bool IsOverdue => IsActive && DateTime.Now > DueDate;

    public void Return(DateTime returnDate)
    {
        if (!IsActive)
            throw new InvalidOperationException("This rental has already been returned");

        ActualReturnDate = returnDate;

        if (returnDate > DueDate)
        {
            var daysLate = (int)(returnDate - DueDate).TotalDays;
            Penalty = daysLate * PenaltyPerDay;
        }
    }
}