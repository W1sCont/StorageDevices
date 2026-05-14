
namespace Devices;

public abstract class Devices 
{
    public string? Brand { get; set; }
    public string? Type { get; set; }
    public string? Title { get; set; }
    public int Capacity { get; set; }
    public int Quantity { get; set; }
    public virtual void Print()
    {
        
    }
}

public class Flash : Devices
{
    public override void Print()
    {
        
    }
}

public class Dvd : Devices
{
    public override void Print()
    {
        
    }
}

public class Hdd : Devices
{
    public override void Print()
    {
        
    }
}