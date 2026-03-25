namespace ConsoleApp1.Domain.Equipment;

public class Laptop : Equipment
{
    public int RamGibabytes { get; private set; }
    public string ProcessorType { get; private set; }

    public Laptop(string name, int ramGibabytes, string processorType) : base(name)
    {
        RamGibabytes = ramGibabytes;
        ProcessorType = processorType;
    }
}