using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace Devices;

[Serializable]
[DataContract]
[KnownType(typeof(Flash))]
[XmlInclude(typeof(Flash))]
[KnownType(typeof(DVD))]
[XmlInclude(typeof(DVD))]
[KnownType(typeof(HDD))]
[XmlInclude(typeof(HDD))]
public abstract class DevicesClass
{
    [DataMember]
    public string? Brand { get; set; }
    [DataMember]
    public string? Type { get; set; }
    [DataMember]
    public string? Title { get; set; }
    [DataMember]
    public int Capacity { get; set; }
    [DataMember]
    public int Quantity { get; set; }
    
    protected DevicesClass() { }
    protected DevicesClass(string? brand, string? type, string? title, int capacity, int quantity)
    {
        Brand = brand;
        Type = type;
        Title = title;
        Capacity = capacity;
        Quantity = quantity;
    }

    public abstract void Print();
}

[Serializable]
[DataContract]
public class Flash : DevicesClass
{
    [DataMember]
    public int Speed { get; set; }
    public Flash() : base() { }
    public Flash(string? brand, string? type, string? title, int capacity, int quantity, int speed) 
        : base(brand, type, title, capacity, quantity){Speed = speed;}
    
    public override void Print()
    {
        Console.WriteLine($"Flash Brand: {Brand}, Type: {Type}, Title: {Title}, Capacity: {Capacity}, Quantity: {Quantity}, Speed: {Speed}");
    }
    public override string ToString()
    {
        return
            $"Flash Brand: {Brand}, Type: {Type}, Title: {Title}, Capacity: {Capacity}, Quantity: {Quantity}, Speed: {Speed}";
    }
}

[Serializable]
[DataContract]
public class DVD : DevicesClass
{
    [DataMember]
    public int WriteSpeed { get; set; }
    public DVD() : base() { }
    public DVD(string? brand, string? type, string? title, int capacity, int quantity, int writeSpeed) 
        : base(brand, type, title, capacity, quantity){WriteSpeed = writeSpeed;}
    public override void Print()
    {
        Console.WriteLine($"DVD Brand: {Brand}, Type: {Type}, Title: {Title}, Capacity: {Capacity}, Quantity: {Quantity}, Write Speed: {WriteSpeed}");

    }
    public override string ToString()
    {
        return
            $"DVD Brand: {Brand}, Type: {Type}, Title: {Title}, Capacity: {Capacity}, Quantity: {Quantity}, Write Speed: {WriteSpeed}";
    }
}

[Serializable]
[DataContract]
public class HDD : DevicesClass
{
    [DataMember]
    public int RPM { get; set; }
    public HDD() : base() { }
    public HDD(string? brand, string? type, string? title, int capacity, int quantity, int rpm) 
        : base(brand, type, title, capacity, quantity){RPM = rpm;}
    public override void Print()
    {
        Console.WriteLine($"HDD Brand: {Brand}, Type: {Type}, Title: {Title}, Capacity: {Capacity}, Quantity: {Quantity}, RPM: {RPM}");

    }
    public override string ToString()
    {
        return
            $"HDD Brand: {Brand}, Type: {Type}, Title: {Title}, Capacity: {Capacity}, Quantity: {Quantity}, RPM: {RPM}";
    }
}