using Devices;
namespace ISerialize;

public interface ISerialize
{
    public void Save(string? path, List<DevicesClass> devices);
    public List<DevicesClass> Load(string? path);
}