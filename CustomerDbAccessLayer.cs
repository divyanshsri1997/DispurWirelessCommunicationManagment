using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DispurWirelessCommunicationManagment
{
    class CustomerDbAccessLayer
    {
        public void InsertintoCustomerTable(Customer c)
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Database=DispurWireless; integrated security=SSPI");
                // writing sql query  
                SqlCommand cm = new SqlCommand
                    ("insert into Customer" +
                    "(registrationId,name,address,mailId,password,mob)" +
                    "values(@registrationId,@name,@address,@mailId,@password,@mob)", con);
                cm.Parameters.AddWithValue("@registrationId", c.RegistrationId);
                cm.Parameters.AddWithValue("@name", c.Name);
                cm.Parameters.AddWithValue("@address", c.Address);
                cm.Parameters.AddWithValue("@mailId", c.MailId);
                cm.Parameters.AddWithValue("@password", c.Password);
                cm.Parameters.AddWithValue("@mob", c.Mob);
                // Opening Connection 
                con.Open();
                // Executing the SQL query  
                int i = cm.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Record Inserted Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong here." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }
        public void FetchCustomerData()
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Database=DispurWireless; integrated security=SSPI");
                // writing sql query  
                SqlCommand cm = new SqlCommand("Select * from Customer", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();
                // Iterating Data  
                while (sdr.Read())
                {
                    Console.WriteLine
                        (sdr["registrationId"] + " " + sdr["name"] + " " + sdr["address"] + " " + sdr["mailId"] + " " + sdr["password"] + " " + sdr["mob"]); // Displaying Record  
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong here." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }

        public void RemoveCustomer(int rid)
        {
            SqlConnection con=null;

            try
            {
                con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Database=DispurWireless; integrated security=SSPI");

                SqlCommand cmd = new SqlCommand("Delete from Customer where registrationId=@regId", con);
                cmd.Parameters.AddWithValue("@regId", rid);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("No of rows affected is = " + i);

            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, Something went wrong  :- " + e);
            }
            finally
            {
                con.Close();
            }
        }
        public bool IdPasswordValidation(int regId, string passwordcheck)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Database=DispurWireless; integrated security=SSPI");

                SqlCommand cmd = new SqlCommand("select * from Customer where registrationId=@regId and password=@passwordcheck", con);
                cmd.Parameters.AddWithValue("@regId", regId);
                cmd.Parameters.AddWithValue("@passwordcheck", passwordcheck);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    return true;
                }
                con.Close();
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, Something went wrong :- " + e);
                return false;
            }
        }
        public void UpdateData(int regId, string changedValue, int ch, long changeNum, string passwordcheck)
        {
            SqlConnection con = null;
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Database=DispurWireless; integrated security=SSPI");

            try
            {
                if (ch == 1)
                {
                    SqlCommand cmd = new SqlCommand("update Customer set name=@name where registrationId=@regId and password=@passwordcheck", con);
                    cmd.Parameters.AddWithValue("@name", changedValue);
                    cmd.Parameters.AddWithValue("@regId", regId);
                    cmd.Parameters.AddWithValue("@passwordcheck", passwordcheck);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    //Console.WriteLine("No of rows affected is = " + i);
                    Console.WriteLine("Name changed successfully");

                }
                else if (ch == 2)
                {
                    SqlCommand cmd = new SqlCommand("update Customer set address=@Address where registrationId=@regId and password=@passwordcheck", con);
                    cmd.Parameters.AddWithValue("@Address", changedValue);
                    cmd.Parameters.AddWithValue("@regId", regId);
                    cmd.Parameters.AddWithValue("@passwordcheck", passwordcheck);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    //Console.WriteLine("No of rows affected is = " + i);
                    Console.WriteLine("Address changed successfully");
                }
                else if (ch == 3)
                {
                    SqlCommand cmd = new SqlCommand("update Customer set mailId=@mailId where registrationId=@regId and password=@passwordcheck", con);
                    cmd.Parameters.AddWithValue("@mailId", changedValue);
                    cmd.Parameters.AddWithValue("@regId", regId);
                    cmd.Parameters.AddWithValue("@passwordcheck", passwordcheck);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    //Console.WriteLine("No of rows affected is = " + i);
                    Console.WriteLine("Email Id changed successfully");
                }
                else if (ch == 4)
                {
                    SqlCommand cmd = new SqlCommand("update Customer set password=@password where registrationId=@regId and password=@passwordcheck", con);
                    cmd.Parameters.AddWithValue("@regId", regId);
                    cmd.Parameters.AddWithValue("@password", changedValue);
                    cmd.Parameters.AddWithValue("@passwordcheck", passwordcheck);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    //Console.WriteLine("No of rows affected is = " + i);
                    Console.WriteLine("Password changed successfully");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("update Customer set mob=@phoneNo where registrationId=@regId and password=@passwordcheck", con);
                    cmd.Parameters.AddWithValue("@regId", regId);
                    cmd.Parameters.AddWithValue("@phoneNo", changeNum);
                    cmd.Parameters.AddWithValue("@passwordcheck", passwordcheck);
                    con.Open();
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
                con.Close();
            }

        }
    }
}
