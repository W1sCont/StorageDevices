using Devices;
using ISerialize;
using PriceList;
namespace StorageDevices
{
    class MainClass
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            try
            {
                PriceListClass priceList = new PriceListClass();
                ILog log = new ConsoleLog();
                
                bool start = true;
                Console.WriteLine("");
                while (start)
                {
                    priceList.Print(log);
                    Console.WriteLine("Enter command");
                    Console.WriteLine("1-Add, 2-Edit, 3-Remove, 4-Print, 5-Search, 6-Save, 7-Load, 0-Exit");
                    string? input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
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
                                    priceList.AddNewDevice(type, brand, title, capacity, quantity, speed);
                                    break;
                                case "2": 
                                    Console.WriteLine("Enter write speed of device:");
                                    speed = int.Parse(Console.ReadLine() ?? "0");
                                    priceList.AddNewDevice(type, brand, title, capacity, quantity, speed);
                                    break;
                                case "3": 
                                    Console.WriteLine("Enter RPM of device:");
                                    speed = int.Parse(Console.ReadLine() ?? "0");
                                    priceList.AddNewDevice(type, brand, title, capacity, quantity, speed);
                                    break;
                                default:
                                    Console.WriteLine("Unknown device type!");
                                    break;
                            }
                            break;
                        case "2":
                            Console.WriteLine("Enter the TITLE of the device you want to EDIT:");
                            string? targetTitle = Console.ReadLine();
                            var device = priceList.Search(targetTitle);
                            if (device == null)
                            {
                                Console.WriteLine("Device not found!");
                                break;
                            }
                            Console.WriteLine($"\nFound device: {device.Brand} {device.Title}");
                            Console.WriteLine($"Enter new Brand (current: {device.Brand}):");
                            string? newBrand = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newBrand)) device.Brand = newBrand;

                            Console.WriteLine($"Enter new Title (current: {device.Title}):");
                            string? newTitle = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newTitle)) device.Title = newTitle;
                            int newCapacity = EditInt($"Enter new Capacity (current: {device.Capacity}):", device.Capacity);
                            int newQuantity = EditInt($"Enter new Quantity (current: {device.Quantity}):", device.Quantity);
                            priceList.Edit(device, newBrand,newTitle,newCapacity,newQuantity);
                            break;
                        case "3":
                            Console.WriteLine("Enter device TITLE to REMOVE:");
                            string? titleToRemove = Console.ReadLine();
                            priceList.Remove(titleToRemove);
                            break;
                        case "4":
                            Console.WriteLine("Select storage type:");
                            Console.WriteLine("1-Console, 2-File");
                            targetTitle = Console.ReadLine();
                            if (targetTitle == "1")
                            {
                                priceList.Print(log);
                            }
                            else if (targetTitle == "2")
                            {
                                ILog logFile = new FileLog();
                                Console.WriteLine("Enter the file name.txt:");
                                string? path = Console.ReadLine();
                                if (path != null) (logFile as FileLog)?.Path = path;
                                priceList.Print(logFile);
                            }
                            else Console.WriteLine("Unknown type!");
                            break;
                        case "5":
                            Console.WriteLine("Enter the TITLE of the device you want to SEARCH:");
                            targetTitle = Console.ReadLine();
                            var searchResult = priceList.Search(targetTitle);
                            if (searchResult != null)
                            {
                                Console.WriteLine($"Found device: {searchResult.Brand} {searchResult.Title}");
                            }
                            else
                            {
                                Console.WriteLine("Device not found!");
                            }
                            break;
                        case "6":
                            Console.WriteLine("Select save type:");
                            Console.WriteLine("1-Soap, 2-XML, 3-JSON");
                            targetTitle = Console.ReadLine();
                            Console.WriteLine("Enter the file name.txt:");
                            string? pathSave = Console.ReadLine();
                            if (targetTitle == "1")
                            {
                                priceList.Save(pathSave, new SoapSerialize());
                            }
                            else if (targetTitle == "2")
                            {
                                priceList.Save(pathSave, new XMLSerialize());
                            }
                            else if (targetTitle == "3")
                            {
                                priceList.Save(pathSave, new JSONSerialize());
                            }
                            else Console.WriteLine("Unknown type!");
                            break;
                        case "7":
                            Console.WriteLine("Select load type:");
                            Console.WriteLine("1-Soap, 2-XML, 3-JSON");
                            targetTitle = Console.ReadLine();
                            Console.WriteLine("Enter the file name.txt:");
                            string? pathLoad = Console.ReadLine();
                            if (targetTitle == "1")
                            {
                                priceList.Load(pathLoad, new SoapSerialize());
                            }
                            else if (targetTitle == "2")
                            {
                                priceList.Load(pathLoad, new XMLSerialize());
                            }
                            else if (targetTitle == "3")
                            {
                                priceList.Load(pathLoad, new JSONSerialize());
                            }
                            else Console.WriteLine("Unknown type!");
                            break;
                        case "0":
                            start = false;
                            break;
                        default:
                            Console.WriteLine("Unknown command!");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static int EditInt(string? message, int value)
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
    }
}