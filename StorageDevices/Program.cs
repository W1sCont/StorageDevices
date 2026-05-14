using StorageDevices;
namespace ProgramExam
{
    class MainClass
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            try
            {
                bool start = true;
                Console.WriteLine("");
                while (start)
                {
                    Console.WriteLine("1-, 2-, 3-, 0-Вихід");
                    string? input = Console.ReadLine();
                    switch (input)
                    {   
                        case "1":
                            Console.WriteLine("");
                            string? input1 = Console.ReadLine();
                            
                            break;
                        case "2":
                            Console.WriteLine("");
                            input1 = Console.ReadLine();
                            
                            break;
                        case "3":
                            Console.WriteLine("");
                            input1 = Console.ReadLine();
                            
                            break; 
                        case "0":
                            start = false;
                            break;
                        default:
                            Console.WriteLine("Не вірна команда");
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