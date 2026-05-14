
namespace Devices;

public abstract class Devices 
{
    public string? Brand { get; set; }
    public string? Type { get; set; }
    public string? Title { get; set; }
    public int Capacity { get; set; }
    public int Quantity { get; set; }
    public virtual void Print() { }
}

public class Flash : Devices
{
    public int Speed { get; set; }
    public override void Print()
    {
        
    }
}

public class DVD : Devices
{
    public int WriteSpeed { get; set; }
    public override void Print()
    {
        
    }
}

public class HDD : Devices
{
    public int RPM { get; set; }
    public override void Print()
    {
        
    }
}