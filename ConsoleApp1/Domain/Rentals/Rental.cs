
using ConsoleApp1.Domain.Equipment;
using ConsoleApp1.Domain.Users;

namespace ConsoleApp1.Domain.Rentals;

public class Rental
{
    public Guid Id { get; }
    public User User { get; }
    
    public Equipment.Equipment Equipment { get; }
    
    public DateTime RentDate { get; }
    public DateTime DueDate { get; }
    public DateTime? ReturnDate { get; private set; }
    public decimal? PenaltyFee { get; private set; }

    public Rental(User user, Equipment.Equipment equipment, int durationInDays)
    {
        Id = Guid.NewGuid();
        User = user;
        Equipment = equipment;
        RentDate = DateTime.Now;
        DueDate = RentDate.AddDays(durationInDays);
    }
    
    public void ReturnEquipment(DateTime returnDate, decimal penaltyFee = 0)
    {
        ReturnDate = returnDate;
        PenaltyFee = penaltyFee;
        Equipment.MarkAsAvailable();
    }
    
}