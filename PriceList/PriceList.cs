using System;
using System.Collections;
using Devices;
namespace PriceList;

public class PriceListClass
{
    private List<DevicesClass> _devices;

    
    public PriceListClass()
    {
        _devices = new List<DevicesClass>();
    }
    
    public void Save(string type, string path)
    {
        
    }
    
    public void Load(string type, string path)
    {
        
    }

    public void AddNewDevice()
    {
        Console.WriteLine("1-Flash, 2-DVD, 3-HDD, 0-Return:");
        string type = Console.ReadLine();

        Console.WriteLine("Enter brand of device:");
        string? brand = Console.ReadLine();
        Console.WriteLine("Enter title of device:");
        string? title = Console.ReadLine();
        Console.WriteLine("Enter capacity of device:");
        int capacity = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter quantity of device:");
        int quantity = int.Parse(Console.ReadLine());
        
        switch (type)
        {
            case "1":
                Console.WriteLine("Enter speed of device:");
                int speed = int.Parse(Console.ReadLine());
                _devices.Add(new Flash(brand, type, title, capacity, quantity, speed));
                break;
            case "2": 
                Console.WriteLine("Enter write speed of device:");
                speed = int.Parse(Console.ReadLine());
                _devices.Add(new DVD(brand, type, title, capacity, quantity, speed));
                break;
            case "3": 
                Console.WriteLine("Enter RPM of device:");
                speed = int.Parse(Console.ReadLine());
                _devices.Add(new HDD(brand, type, title, capacity, quantity, speed));
                break;
            default:
                Console.WriteLine("Unknown device type!");
                break;
        }
    }

    public void Remove(string name)
    {
        
    }

    public void Edit(string name)
    {
        
    }
    
    public void Search(string name)
    {
        
    }
    
    public void Print()
    {
        foreach (var device in _devices)
        {
            device.Print();
        }
    }
}
