using Devices;
namespace PriceList;

public class PriceListClass
{
    private List<DevicesClass> _devices;

    
    public PriceListClass()
    {
        _devices = new List<DevicesClass>();
    }
    
    public void Save(string? path, ISerialize.ISerialize obj)
    {
        obj.Save(path, _devices);
    }
    
    public void Load(string? path, ISerialize.ISerialize obj)
    {
        List<DevicesClass> loadedDevices = obj.Load(path);
        this._devices = loadedDevices;
    }

    public void AddNewDevice()
    {
        Console.WriteLine("1-Flash, 2-DVD, 3-HDD, 0-Return:");
        string? type = Console.ReadLine();

        Console.WriteLine("Enter brand of device:");
        string? brand = Console.ReadLine();
        Console.WriteLine("Enter title of device:");
        string? title = Console.ReadLine();
        Console.WriteLine("Enter capacity of device:");
        int capacity = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine("Enter quantity of device:");
        int quantity = int.Parse(Console.ReadLine() ?? "0");
        
        switch (type)
        {
            case "1":
                Console.WriteLine("Enter speed of device:");
                int speed = int.Parse(Console.ReadLine() ?? "0");
                _devices.Add(new Flash(brand, type, title, capacity, quantity, speed));
                break;
            case "2": 
                Console.WriteLine("Enter write speed of device:");
                speed = int.Parse(Console.ReadLine() ?? "0");
                _devices.Add(new DVD(brand, type, title, capacity, quantity, speed));
                break;
            case "3": 
                Console.WriteLine("Enter RPM of device:");
                speed = int.Parse(Console.ReadLine() ?? "0");
                _devices.Add(new HDD(brand, type, title, capacity, quantity, speed));
                break;
            default:
                Console.WriteLine("Unknown device type!");
                break;
        }
    }

    public void Remove(string? titleToRemove)
    {
        if (titleToRemove == null) return;
        var device = _devices.Find(d => d.Title == titleToRemove);
        if (device != null) { _devices.Remove(device); }
    }

    public void Edit(string? targetTitle)
    {
        var device = _devices.Find(d => d.Title != null && 
                                        d.Title.Equals(targetTitle, StringComparison.OrdinalIgnoreCase));
        if (device == null)
        {
            Console.WriteLine("Device not found!");
            return;
        }
        Console.WriteLine($"\nFound device: {device.Brand} {device.Title}");
        Console.WriteLine($"Enter new Brand (current: {device.Brand}):");
        string? newBrand = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newBrand)) device.Brand = newBrand;

        Console.WriteLine($"Enter new Title (current: {device.Title}):");
        string? newTitle = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newTitle)) device.Title = newTitle;
        device.Capacity = EditInt($"Enter new Capacity (current: {device.Capacity}):", device.Capacity);
        device.Quantity = EditInt($"Enter new Quantity (current: {device.Quantity}):", device.Quantity);
        
        if (device is Flash flash) 
        { flash.Speed = EditInt($"Enter new Speed (current: {flash.Speed}):", flash.Speed); }
        else if (device is DVD dvd) { dvd.WriteSpeed = EditInt($"Enter new Write Speed (current: {dvd.WriteSpeed}):", dvd.WriteSpeed); }
        else if (device is HDD hdd) { hdd.RPM = EditInt($"Enter new RPM (current: {hdd.RPM}):", hdd.RPM); }
    }

    private int EditInt(string? message, int value)
    {
        while (true)
        {
            Console.WriteLine(message);
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return value;
            if (int.TryParse(input, out int result)) return result;
            Console.WriteLine("Invalid number. Try again or press Enter to skip.");
        }
    }
    
    public void Search(string? title)
    {
        var searchResult = _devices.Find(d => d.Title != null && 
                                            d.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (searchResult != null)
        {
            Console.WriteLine($"Found device: {searchResult.Brand} {searchResult.Title}");
        }
        else
        {
            Console.WriteLine("Device not found!");
        }
    }

    public void Print(ILog log)
    {
        foreach (var device in _devices)
        {
            string? report = device.ToString();
            log.Print(report);
        }
    }
}
