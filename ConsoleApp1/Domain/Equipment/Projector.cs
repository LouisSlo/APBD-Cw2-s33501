namespace ConsoleApp1.Domain.Equipment;

public class Projector : Equipment
{
    public int Brightness { get; private set; }
    public bool HasHDR { get; private set; }
    public Projector(string name, int brightness, bool hasHdr) : base(name)
    {
        Brightness = brightness;
        HasHDR = hasHdr;
    }
}