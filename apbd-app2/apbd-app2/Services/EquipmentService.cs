using apbd_app2.Domain.Models;

namespace apbd_app2.Services;

public class EquipmentService : IEquipmentService
{
    private readonly List<Equipment> _equipmentList = new List<Equipment>();

    public void AddEquipment(Equipment equipment)
    {
        _equipmentList.Add(equipment);
    }

    public List<Equipment> GetAll()
    {
        return _equipmentList;
    }

    public List<Equipment> GetAvailable()
    {
        return _equipmentList.Where(e => e.IsAvailable).ToList();
    }

    public Equipment? GetById(Guid id)
    {
        return _equipmentList.FirstOrDefault(e => e.Id == id);
    }

    public void MarkAsUnavailable(Guid equipmentId)
    {
        var equipment = GetById(equipmentId)
                        ?? throw new InvalidOperationException("Equipment not found.");

        equipment.MarkAsUnavailable();
    }
}