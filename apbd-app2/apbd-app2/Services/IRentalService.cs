using apbd_app2.Domain.Models;

namespace apbd_app2.Services;

public interface IRentalService
{
    public Rental RentEquipment(User user, Equipment equipment, DateTime dueDate);
    public Rental ReturnEquipment(Guid rentalId, DateTime returnDate);
    public List<Rental> GetActiveRentals(Guid userId);
    public List<Rental> GetOverdueRentals();
    public string GenerateReport();
}