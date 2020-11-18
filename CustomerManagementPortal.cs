using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Xceed.Wpf.Toolkit;

namespace DispurWirelessCommunicationManagment
{
    public class CustomerManagementPortal
    {
        public static string connectionString = @"Data Source=01HW1742644\SQLEXPRESS;Initial Catalog=Case study;Integrated Security=True;";
        public void AddDataToSql(string name, string address, string mailId, string password, long mob)
        {
            SqlConnection sqlconn = new SqlConnection(connectionString);

            try
            {

                SqlCommand cmd = new SqlCommand("Insert into CustomerTable values(@name,@address,@mailId,@password,@mob)", sqlconn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@mailId", mailId);
                cmd.Parameters.AddWithValue("@mob", mob);
                sqlconn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("No of rows affected is = " + i);
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, Something went wrong :- " + e);
            }
            finally
            {
                sqlconn.Close();
            }
        }
        public void RemoveData(int regId)
            {
                SqlConnection sqlconn = new SqlConnection(connectionString);

                try
                {

                    SqlCommand cmd = new SqlCommand("Delete from CustomerTable where RegId=@regId", sqlconn);
                    cmd.Parameters.AddWithValue("@regId", regId);
                    sqlconn.Open();
                    int i = cmd.ExecuteNonQuery();
                    Console.WriteLine("No of rows affected is = " + i);
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oops, Something went wrong  :- " + e);
                }
                finally
                {
                    sqlconn.Close();
                }

            }

        public void UpdateData(int regId,string changedValue,int ch,int changeNum,string passwordcheck) 
        {
            SqlConnection sqlconn = new SqlConnection(connectionString);

            try
            {
                if (ch == 1) {
                    SqlCommand cmd = new SqlCommand("update CustomerTable set name=@name where RegId=@regId and password=@passwordcheck", sqlconn);
                    cmd.Parameters.AddWithValue("@name", changedValue);
                    cmd.Parameters.AddWithValue("@regId", regId);
                    cmd.Parameters.AddWithValue("@passwordcheck", passwordcheck);
                    sqlconn.Open();
                    int i = cmd.ExecuteNonQuery();
                    //Console.WriteLine("No of rows affected is = " + i);
                    Console.WriteLine("Name changed successfully");
                   
                }
                else if (ch == 2)
                {
                    SqlCommand cmd = new SqlCommand("update CustomerTable set address=@Address where RegId=@regId and password=@passwordcheck", sqlconn);
                    cmd.Parameters.AddWithValue("@Address", changedValue);
                    cmd.Parameters.AddWithValue("@regId", regId);
                    cmd.Parameters.AddWithValue("@passwordcheck", passwordcheck);
                    sqlconn.Open();
                    int i = cmd.ExecuteNonQuery();
                    //Console.WriteLine("No of rows affected is = " + i);
                    Console.WriteLine("Address changed successfully");
                }
                else if (ch == 3)
                {
                    SqlCommand cmd = new SqlCommand("update CustomerTable set mailId=@mailId where RegId=@regId and password=@passwordcheck", sqlconn);
                    cmd.Parameters.AddWithValue("@mailId", changedValue);
                    cmd.Parameters.AddWithValue("@regId", regId);
                    cmd.Parameters.AddWithValue("@passwordcheck", passwordcheck);
                    sqlconn.Open();
                    int i = cmd.ExecuteNonQuery();
                    //Console.WriteLine("No of rows affected is = " + i);
                    Console.WriteLine("Email Id changed successfully");
                }
                else if(ch == 4)
                {
                    SqlCommand cmd = new SqlCommand("update CustomerTable set password=@password where RegId=@regId and password=@passwordcheck", sqlconn);
                    cmd.Parameters.AddWithValue("@regId", regId);
                    cmd.Parameters.AddWithValue("@password", changedValue);
                    cmd.Parameters.AddWithValue("@passwordcheck", passwordcheck);
                    sqlconn.Open();
                    int i = cmd.ExecuteNonQuery();
                    //Console.WriteLine("No of rows affected is = " + i);
                    Console.WriteLine("Password changed successfully");
                }
                else 
                {
                    SqlCommand cmd = new SqlCommand("update CustomerTable set phoneNo=@phoneNo where RegId=@regId and password=@passwordcheck", sqlconn);
                    cmd.Parameters.AddWithValue("@regId", regId);
                    cmd.Parameters.AddWithValue("@phoneNo", changeNum);
                    cmd.Parameters.AddWithValue("@passwordcheck", passwordcheck);
                    sqlconn.Open();
                    int i = cmd.ExecuteNonQuery();
                    //Console.WriteLine("No of rows affected is = " + i);
                    Console.WriteLine("Phone number changed successfully");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, Something went wrong :- " + e);
            }
            finally
            {
                sqlconn.Close();
            }

        }
        public bool IdPasswordValidation(int regId,string passwordcheck)
        {
            SqlConnection sqlconn = new SqlConnection(connectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("select * from CustomerTable where regId=@regId and password=@passwordcheck", sqlconn);
                cmd.Parameters.AddWithValue("@regId", regId);
                cmd.Parameters.AddWithValue("@passwordcheck", passwordcheck);
                sqlconn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    return true;
                }
                sqlconn.Close();
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, Something went wrong :- " + e);
                return false;
            }
        }
        public void DisplayData()
        {
            SqlConnection sqlconn = new SqlConnection(connectionString);

            try
            {

                SqlCommand cmd = new SqlCommand("select * from CustomerTable", sqlconn);
                sqlconn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["RegId"] + " " + sdr["name"] + " " + sdr["address"] + " " + sdr["mailId"] + " " + sdr["password"] + " " + sdr["phoneNo"] + " ");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, Something went wrong :- " + e);
            }
            finally
            {
                sqlconn.Close();
            }
        }
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
                        AddDataToSql(name, address, mailId, password, mob);
                        Console.WriteLine("Please make a note of your Registration ID :" + c.RegistrationId);
                        Console.WriteLine("--------------------------------------------------------------------------");
                        break;
                    case 2:
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("Customer Details...\n\n");
                        DisplayData();
                        Console.WriteLine("--------------------------------------------------------------------------");
                        break;
                    case 3:
                        //Things to add 
                        // 1) password verification before updating
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("Update Customer Data Page...\n\n");
                        Console.WriteLine("Enter Registration Id ");
                        int id1 = Convert.ToInt32(Console.ReadLine());  //regid
                        Console.WriteLine("Enter Password");
                        string passwordCheck = Console.ReadLine(); // for password confirmation before updating
                        int ch;                                                         //choice
                        if (IdPasswordValidation(id1, passwordCheck)) { 
                        do {
                            Console.WriteLine("Choose what to update");
                            Console.WriteLine("1) Name");
                            Console.WriteLine("2) Address");
                            Console.WriteLine("3) Mail Id");
                            Console.WriteLine("4) PassWord");
                            Console.WriteLine("5) Phone no");
                            Console.WriteLine("6) Exit");
                            ch = Convert.ToInt32(Console.ReadLine());
                            switch (ch)
                            {
                                case 1: Console.WriteLine("Enter new name to update");
                                    string n1 = Console.ReadLine();
                                    UpdateData(id1, n1, ch, 0, passwordCheck);
                                    break;
                                case 2:
                                    Console.WriteLine("Enter new Address to update");
                                    string a1 = Console.ReadLine();
                                    UpdateData(id1, a1, ch, 0, passwordCheck);
                                    break;
                                case 3:
                                    Console.WriteLine("Enter new mail id to update");
                                    string m1 = Console.ReadLine();
                                    UpdateData(id1, m1, ch, 0, passwordCheck);
                                    break;
                                case 4:
                                    Console.WriteLine("Enter new password to update");
                                    string p1 = Console.ReadLine();
                                    
                                    UpdateData(id1, p1, ch, 0,passwordCheck);
                                    break;
                                case 5:
                                    Console.WriteLine("Enter new phone number to update");
                                    int pn1 = Convert.ToInt32(Console.ReadLine());
                                    UpdateData(id1, null, ch, pn1, passwordCheck);
                                    break;
                                default: break;
                            }
                        } while (ch != 6);
                        }
                        else
                        {
                            Console.WriteLine("Registration Id or password incorrect");
                        }

                        Console.WriteLine("--------------------------------------------------------------------------");
                        break;

                    case 4:
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("Remove Customer...\n\n");
                        Console.WriteLine("Enter registration id to remove");
                        int id = Convert.ToInt32(Console.ReadLine());
                        RemoveData(id);
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
