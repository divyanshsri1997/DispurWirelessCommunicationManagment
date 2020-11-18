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
    }
}
//Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = ma
