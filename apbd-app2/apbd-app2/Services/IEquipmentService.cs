using apbd_app2.Domain.Models;

namespace apbd_app2.Services;

public interface IEquipmentService
{
    public void AddEquipment(Equipment equipment);
    public List<Equipment> GetAll();
    public List<Equipment> GetAvailable();
    public Equipment? GetById(Guid id);
    public void MarkAsUnavailable(Guid equipmentId);
}