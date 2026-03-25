namespace ConsoleApp1.Infrastructure.Repositories;

using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Domain.Equipment;
public class EquipmentRepository
{
    private readonly List<Equipment> _equipment = new ();
    
    public void Add(Equipment equipment) => _equipment.Add(equipment);
    
    public Equipment? GetById(Guid id) => _equipment.FirstOrDefault(e => e.Id == id);
    
    public List<Equipment> GetAll() => _equipment;
    
    public List<Equipment> GetAvailable() => _equipment.Where(e => e.IsAvaliable).ToList();
}