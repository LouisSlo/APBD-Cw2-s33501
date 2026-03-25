using ConsoleApp1.Domain.Rentals;

namespace ConsoleApp1.Application.Policies;

public interface IPenaltyCalculator
{
    decimal CalculatePenalty(DateTime dueDate, DateTime returnDate);
}