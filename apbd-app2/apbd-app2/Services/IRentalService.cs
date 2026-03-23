using apbd_app2.Domain.Models;

namespace apbd_app2.Services;

public interface IRentalService
{
    public Rental RentEquipment(Guid userId, Guid equipmentId, DateTime dueDate);
    public Rental ReturnEquipment(Guid rentalId, DateTime returnDate);
    public List<Rental> GetActiveRentals(Guid userId);
    public List<Rental> GetOverdueRentals();
    public string GenerateReport();
}