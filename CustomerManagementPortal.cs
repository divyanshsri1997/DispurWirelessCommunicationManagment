using System;
using System.Collections.Generic;
using System.Text;

namespace DispurWirelessCommunicationManagment
{
    public class CustomerManagementPortal
    {
        public CustomerManagementPortal()
        {
            while (true)
            {
                Console.WriteLine("Press 1 for New Customer Registration...");
                Console.WriteLine("Press 2 to View Customer details(Relationship Manager*)...");
                Console.WriteLine("Press 3 to update customer data...");
                Console.WriteLine("Press 4 to Remove Customer data...");
                Console.WriteLine("Press 5 to move back to main menu...");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("Welcome to the Registration Page...\n\n");
                        Console.WriteLine("####Enter Your Details####\n");
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Address: ");
                        string address = Console.ReadLine();
                        Console.Write("Enter Email-id: ");
                        string mailId = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        string password = Console.ReadLine();
                        Console.Write("Confirm password: ");
                        string confrimPass = Console.ReadLine();
                        if(password != confrimPass)
                        {
                            Console.WriteLine("Passwords didnt match...\n\n");
                            break;
                        }
                        Console.Write("Enter contact details(if any): ");
                        long mob = long.Parse(Console.ReadLine());
                        Customer c = new Customer(name, address, mailId,password,mob);
                        new CustomerDbAccessLayer().InsertintoCustomerTable(c);
                        Console.WriteLine("Please make a note of your Registration ID :" + c.RegistrationId);
                        Console.WriteLine("--------------------------------------------------------------------------");
                        break;
                    case 2:
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("........Relationship Manager........");
                        Console.Write("Enter your ID: ");
                        int rId = int.Parse(Console.ReadLine());
                        Console.Write("Enter your password: ");
                        string p = Console.ReadLine();
                        if(rId == 505 && p.ToLower() == "rm")
                        {
                            Console.WriteLine("\n\n####Customer Details####\n");
                            new CustomerDbAccessLayer().FetchCustomerData();
                        }else
                        {
                            Console.WriteLine("Wrong credentials....\n\n");
                            break;
                        }
                        
                        Console.WriteLine("--------------------------------------------------------------------------");
                        break;
                    case 3:
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("Update Customer Data Page...\n\n");
                        Console.WriteLine("--------------------------------------------------------------------------");
                        break;
                    case 4:
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("Remove Customer...\n\n");
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
                if(choice == 5)
                {
                    break;
                }
            }
        }
    }
}
