using System;
using System.Collections.Generic;
using System.Text;

namespace DispurWirelessCommunicationManagment
{
    class TarrifPlanManagementPortal
    {
        public static bool AuthenticateAdmin()
        {
            Console.Write("Enter Admin ID: ");
            int AId = int.Parse(Console.ReadLine());
            Console.Write("Enter Admin password: ");
            string pwd = Console.ReadLine();
            if (AId == 505 && pwd.ToLower() == "rm")
            {
                Console.WriteLine("\n\n####....Welcome Admin....####\n");
                return true;
            }
            else
            {
                Console.WriteLine("Wrong credentials....\n\n");
                return false;
            }
        }
        public TarrifPlanManagementPortal()
        {
            while (true)
            {
                Console.WriteLine("Press 1 to Add New Tarrif Plan...");
                Console.WriteLine("Press 2 to View Plan details...");
                Console.WriteLine("Press 3 to Remove a Plan...");
                Console.WriteLine("Press 4 to update tarrif for a plan...");
                Console.WriteLine("Press 5 to move back to main menu...");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("Welcome to the Tarrif Plan Page...\n\n");
                        bool result = AuthenticateAdmin();
                        if (result)
                        {
                            Console.WriteLine("####Enter the Details####\n");
                            Console.Write("Enter plan name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter paln type: ");
                            string type = Console.ReadLine();
                            Console.Write("Enter tarrif(rate/min): ");
                            int tarrif = int.Parse(Console.ReadLine());
                            Console.Write("Enter validity: ");
                            int validity = int.Parse(Console.ReadLine());
                            Console.Write("Enter rental(if any): ");
                            int rental = int.Parse(Console.ReadLine());
                            TarrifPlan tp = new TarrifPlan(name, type, tarrif, validity, rental);
                            new TarrifPlanDbAccessLayer().InsertintoTarrifPlanTable(tp);
                            Console.WriteLine("Please make a note of the Plan ID :" + tp.PlanId);
                        }
                        Console.WriteLine("--------------------------------------------------------------------------");
                        break;
                    case 2:
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("........Voice/Data Plans........");
                        new TarrifPlanDbAccessLayer().FetchPlanData();
                        Console.WriteLine("--------------------------------------------------------------------------");
                        break;
                    case 3:
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("Remove Plan Page...\n\n");
                        bool isAuthencated = AuthenticateAdmin();
                        if(isAuthencated)
                        {
                            Console.Write("Enter plan ID: ");
                            int id = int.Parse(Console.ReadLine());
                            new TarrifPlanDbAccessLayer().RemovePlan(id);
                        }
                        
                        Console.WriteLine("--------------------------------------------------------------------------");
                        break;
                    case 4:
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("Update Tarrif Page...\n\n");
                        bool isAdmin = AuthenticateAdmin();
                        if(isAdmin)
                        {
                            Console.Write("Enter plan ID: ");
                            int id1 = int.Parse(Console.ReadLine());
                            Console.Write("Enter new tarrif: ");
                            int t = int.Parse(Console.ReadLine());
                            new TarrifPlanDbAccessLayer().UpdateTarrif(id1, t);
                        }
                        Console.WriteLine("--------------------------------------------------------------------------");
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("Please enter correct choice...\n\n");
                        Console.WriteLine("--------------------------------------------------------------------------");
                        break;
                }
                if (choice == 5)
                {
                    break;
                }
            }
        }
    }
}
