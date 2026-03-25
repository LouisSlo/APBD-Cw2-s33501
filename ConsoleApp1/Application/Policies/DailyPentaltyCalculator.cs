namespace ConsoleApp1.Application.Policies;


public class DailyPenaltyCalculator : IPenaltyCalculator
{
    private readonly decimal _dailyRate;

    public DailyPenaltyCalculator(decimal dailyRate = 10m)
    {
        _dailyRate = dailyRate;
    }

    public decimal CalculatePenalty(DateTime dueDate, DateTime returnDate)
    {
        if(returnDate <= dueDate)
            return 0;
        var daysLate = (returnDate - dueDate).Days;
        return daysLate * _dailyRate;
    }
}