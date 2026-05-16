using Devices;
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
                
                
                bool start = true;
                Console.WriteLine("");
                while (start)
                {
                    priceList.Print();
                    Console.WriteLine("Enter command");
                    Console.WriteLine("1-Add, 2-Edit, 3-Remove, 4-Search, 5-Sort, 6-Save, 7-Load, 8-Iterator" +
                                      " \n9-SaveSoap, 10-LoadSoap, 11-SaveXml, 12-LoadXml, 13-SaveJson, 14-LoadJson, 0-Exit");
                    string? input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            priceList.AddNewDevice();
                            break;
                        case "2":
                            break;
                        case "3":
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