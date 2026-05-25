using Devices;
using System.Runtime.Serialization.Json;
namespace ISerialize;

public class JSONSerialize : ISerialize
{
    public void Save(string? path, List<DevicesClass> devices)
    {
        if (string.IsNullOrEmpty(path)) return;
        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<DevicesClass>));
        using FileStream stream = new FileStream(path, FileMode.Create);
        jsonFormatter.WriteObject(stream, devices);
    }
    public List<DevicesClass> Load(string? path)
    {
        try
        {
            if (string.IsNullOrEmpty(path) || !File.Exists(path)) return new List<DevicesClass>();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<DevicesClass>));
            using FileStream stream = new FileStream(path, FileMode.Open);
            List<DevicesClass>? arr = jsonFormatter.ReadObject(stream) as List<DevicesClass>;  
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