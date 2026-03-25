namespace ConsoleApp1.Domain.Equipment;

public class Camera : Equipment
{
   public int Megapixels { get; private set; } 
   public bool HasInterchangeableLens { get; private set; }
   public Camera(string name, int megapixels, bool hasInterchangeableLens) : base(name)
      {
       Megapixels = megapixels;
       HasInterchangeableLens = hasInterchangeableLens;
      }
}