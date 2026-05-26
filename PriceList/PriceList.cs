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

    public void AddNewDevice(string? type, string? brand,string? title, int capacity,int quantity,int speed)
    {
        switch (type)
        {
            case "1":
                _devices.Add(new Flash(brand, type, title, capacity, quantity, speed));
                break;
            case "2": 
                _devices.Add(new DVD(brand, type, title, capacity, quantity, speed));
                break;
            case "3": 
                _devices.Add(new HDD(brand, type, title, capacity, quantity, speed));
                break;
        }
    }

    public void Remove(string? titleToRemove)
    {
        if (titleToRemove == null) return;
        var device = _devices.Find(d => d.Title == titleToRemove);
        if (device != null) { _devices.Remove(device); }
    }

    public void Edit(DevicesClass obj, string? brand,string? title, int capacity,int quantity, int speed)
    {
        obj.Brand = brand;
        obj.Title = title;
        obj.Capacity = capacity;
        obj.Quantity = quantity;
        if (obj is Flash flash) flash.Speed = speed;
        else if (obj is DVD dvd) dvd.WriteSpeed = speed;
        else if (obj is HDD hdd) hdd.RPM = speed;
    }
    
    public DevicesClass? Search(string? title)
    {
        var searchResult = _devices.Find(d => d.Title != null && 
                                            d.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        return searchResult;
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
