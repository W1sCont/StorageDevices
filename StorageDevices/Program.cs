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
                            priceList.AddNewDevice();
                            break;
                        case "2":
                            Console.WriteLine("Enter the TITLE of the device you want to EDIT:");
                            string? targetTitle = Console.ReadLine();
                            priceList.Edit(targetTitle);
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
                            priceList.Search(targetTitle);
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
    }
}