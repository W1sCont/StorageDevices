using Devices;
using System.IO;

namespace StorageDevices;

public class FileLog : ILog
{
    public string? Path { get; set;}
    public void Print(string? message)
    {
        if (Path != null)
        {
            using var sw = new StreamWriter(Path, true);
            sw.WriteLine(message);
        }
    }
}