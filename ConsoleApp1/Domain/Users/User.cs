namespace ConsoleApp1.Domain.Users;

public abstract class User
{
    public Guid Id { get; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    
    public abstract string UserType { get; }
    
    protected User(string firstName, string lastName)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
    }
}