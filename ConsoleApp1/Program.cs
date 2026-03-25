namespace ConsoleApp1;

using System;
using ConsoleApp1.Application.Policies;
using ConsoleApp1.Application.Services;
using ConsoleApp1.Domain.Equipment;
using ConsoleApp1.Domain.Users;
using ConsoleApp1.Infrastructure.Repositories;

public class Program
{
    public static void Main(string[] args)
    {
        
        Console.WriteLine(" ------------ EQUIPMENT RENTAL SYSTEM ------------");

        var equipmentRepo = new EquipmentRepository();
        var userRepo = new Userrepository();
        var rentalRepo = new RentalRepository();
        var limitPolicy = new StandardUserLimitPolicy();
        var penaltyCalculator = new DailyPenaltyCalculator(15m);
        var rentalService = new RentalService(rentalRepo, limitPolicy, penaltyCalculator);

        var laptop = new Laptop("Dell XPS 15", 16, "Intel Core i7");
        var camera = new Camera("Sony A7 III", 24, true);
        var projector = new Projector("Epson 1080p", 3000, "2160p");
        
        equipmentRepo.Add(laptop);
        equipmentRepo.Add(camera);
        equipmentRepo.Add(projector);
        Console.WriteLine("\n[OK] Equipment added to the system" );
        
        var student = new Student("Jan", "Kowalski", "s1765");
        var employee = new Employee("Anna", "Nowak", "IT Department");
        
        userRepo.Add(student);
        userRepo.Add(employee);
        Console.WriteLine("[OK] Users added to the system");
        
        Console.WriteLine("\\n---Attempting a valid rental -----");
        var rental1 = rentalService.rentEquipment(student, laptop, 7);
        Console.WriteLine($"SUCCESS: Rental of {laptop.Name} for {student.FirstName} completed successfully.");

        Console.WriteLine("\n ---------- Attempting to rent unavaliable equipment ----------");
        try
        {
            rentalService.rentEquipment(employee, laptop, 3);
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR: {e.Message}");
        }
        
        Console.WriteLine("\n ------ Attempting to exceed rental limit-------");
        try
        {
            var rental2 = rentalService.rentEquipment(student, projector, 2);
            var rental3 = rentalService.rentEquipment(student, camera, 2);
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR: {e.Message}");
        }
        
        Console.WriteLine("\n ---- On time return ----");
        rentalService.ReturnEquipment(rental1,DateTime.Now.AddDays(5));
        Console.WriteLine($"SUCCESS: {rental1.Equipment.Name} returned to the system.");
        
        foreach (var r in rentalRepo.GetAll().Where(r => r.Equipment.Name == projector.Name && r.ReturnDate == null).ToList())
        {
             rentalService.ReturnEquipment(r, DateTime.Now);
        }

        Console.WriteLine("\n --- Late return ----");
        var employeeRental = rentalService.rentEquipment(employee, projector, 2);
        rentalService.ReturnEquipment(employeeRental,DateTime.Now.AddDays(5));
        Console.WriteLine($"SUCCESS: {employeeRental.Equipment.Name} returned to the system.");
        
        Console.WriteLine("\n -------- FINAL SYSTEM REPORT ------");
        Console.WriteLine("Equipment status:");
        foreach (var eq in equipmentRepo.GetAll())
        {
            var status = eq.IsAvaliable ? "Available" : "Unavailable(Rented)";
            Console.WriteLine($"- {eq.Name}: {status}");
        }
    }
}

