namespace ConsoleApp1.Domain.Users;

public class Student : User
{
    public string IndexNumber { get; private set; }
    public override string UserType => "Student";

    public Student(string firstName, string lastName, string indexNumber)
        : base(firstName, lastName)
    {
        IndexNumber = indexNumber;
    }
}