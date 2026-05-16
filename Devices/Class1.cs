
namespace Devices;

public abstract class DevicesClass
{
    public string? Brand { get; set; }
    public string? Type { get; set; }
    public string? Title { get; set; }
    public int Capacity { get; set; }
    public int Quantity { get; set; }
    
    protected DevicesClass(string brand, string type, string title, int capacity, int quantity)
    {
        Brand = brand;
        Type = type;
        Title = title;
        Capacity = capacity;
        Quantity = quantity;
    }

    public abstract void Print();
}

public class Flash : DevicesClass
{
    public int Speed { get; set; }

    public Flash(string brand, string type, string title, int capacity, int quantity, int speed) 
        : base(brand, type, title, capacity, quantity){Speed = speed;}
    
    public override void Print()
    {
        Console.WriteLine($"Flash Brand: {Brand}, Type: {Type}, Title: {Title}, Capacity: {Capacity}, Quantity: {Quantity}, Speed: {Speed}");
    }
}

public class DVD : DevicesClass
{
    public int WriteSpeed { get; set; }
    
    public DVD(string brand, string type, string title, int capacity, int quantity, int writeSpeed) 
        : base(brand, type, title, capacity, quantity){WriteSpeed = writeSpeed;}
    public override void Print()
    {
        
    }
}

public class HDD : DevicesClass
{
    public int RPM { get; set; }
    
    public HDD(string brand, string type, string title, int capacity, int quantity, int rpm) 
        : base(brand, type, title, capacity, quantity){RPM = rpm;}
    public override void Print()
    {
        
    }
}