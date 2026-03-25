namespace ConsoleApp1.Domain.Equipment;

public abstract class Equipment
{
    public Guid Id { get; }
    public string Name { get; private set; }
    public bool IsAvaliable { get; private set; }

    protected Equipment(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        IsAvaliable = true;
    }
    public void MarkAsUnavailable()
    {
        IsAvaliable = false;
    }
    public void MarkAsAvailable()
    {
        IsAvaliable = true;
    }
}