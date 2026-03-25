namespace ConsoleApp1.Domain.Users;

public class Employee : User
{
    public string Department { get; private set; }
    public override string UserType => "Employee";
    public Employee(string firstName, string lastName, string department) : base(firstName, lastName)
    {
        Department = department;
    }
}