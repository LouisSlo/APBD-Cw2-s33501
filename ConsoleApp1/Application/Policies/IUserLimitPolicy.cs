namespace ConsoleApp1.Application.Policies;

using ConsoleApp1.Domain.Users;

public interface IUserLimitPolicy
{
    int GetMaxActiveRentals(User user);
}