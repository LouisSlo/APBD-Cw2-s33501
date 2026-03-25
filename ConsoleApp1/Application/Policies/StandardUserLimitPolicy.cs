namespace ConsoleApp1.Application.Policies;

using ConsoleApp1.Domain.Users;

public class StandardUserLimitPolicy : IUserLimitPolicy
{
    public int GetMaxActiveRentals(User user)
    {
        return user switch
        {
            Student => 2,
            Employee => 5,
            _ => 1
        };
    }
}