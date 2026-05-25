using System.Xml.Serialization;
using Devices;
namespace ISerialize;

public class XMLSerialize : ISerialize
{   
    public void Save(string? path, List<DevicesClass> devices)
    {
        if (string.IsNullOrEmpty(path)) return;
        using FileStream stream = new FileStream(path, FileMode.Create);
        XmlSerializer serializer = new XmlSerializer(typeof(List<DevicesClass>));
        serializer.Serialize(stream, devices);
    }
    public List<DevicesClass> Load(string? path)
    {
        try
        {
            if (string.IsNullOrEmpty(path) || !File.Exists(path)) return new List<DevicesClass>();
            using FileStream stream = new FileStream(path, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(List<DevicesClass>));
            List<DevicesClass>? arr = serializer.Deserialize(stream) as List<DevicesClass>; 
            return arr ?? new List<DevicesClass>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Error details: {ex.InnerException.Message}");
            }
            return new List<DevicesClass>();
        }
    }
}