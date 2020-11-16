using System;

namespace DispurWirelessCommunicationManagment
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true) {
                Console.WriteLine("Press 1 for Customer Management Portal...");
                Console.WriteLine("Press 2 for Tariff Plan Management Portal...");
                Console.WriteLine("Press 3 for Connection Management Portal...");
                Console.WriteLine("Press 4 for Usage Management Portal...");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("Customer Management Portal...\n\n");
                        new CustomerManagementPortal();
                        Console.WriteLine("--------------------------------------------------------------------------");
                        break;
                    case 2:
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("Tariff Plan Management Portal...\n\n");
                        Console.WriteLine("--------------------------------------------------------------------------");
                        break;
                    case 3:
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("Connection Management Portal...\n\n");
                        Console.WriteLine("--------------------------------------------------------------------------");
                        break;
                    case 4:
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("Usage Management Portal...\n\n");
                        Console.WriteLine("--------------------------------------------------------------------------");
                        break;
                    default:
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("Please enter correct choice...\n\n");
                        Console.WriteLine("--------------------------------------------------------------------------");
                        break;
                }
            }
            
        }
    }
}
