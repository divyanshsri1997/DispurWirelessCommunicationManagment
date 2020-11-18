using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DispurWirelessCommunicationManagment
{
    class TarrifPlanDbAccessLayer
    {
        public void InsertintoTarrifPlanTable(TarrifPlan tp)
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Database=DispurWireless; integrated security=SSPI");
                // writing sql query  
                SqlCommand cm = new SqlCommand
                    ("insert into TarrifPlan" +
                    "(planId,name,type,tarrif,validity,rental)" +
                    "values(@planId,@name,@type,@tarrif,@validity,@rental)", con);
                cm.Parameters.AddWithValue("@planId", tp.PlanId);
                cm.Parameters.AddWithValue("@name", tp.Name);
                cm.Parameters.AddWithValue("@type", tp.Type);
                cm.Parameters.AddWithValue("@tarrif", tp.Tarrif);
                cm.Parameters.AddWithValue("@validity", tp.Validity);
                cm.Parameters.AddWithValue("@rental", tp.Rental);
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
        public void FetchPlanData()
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Database=DispurWireless; integrated security=SSPI");
                // writing sql query  
                SqlCommand cm = new SqlCommand("Select * from TarrifPlan", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();
                // Iterating Data  
                while (sdr.Read())
                {
                    Console.WriteLine
                        (sdr["planId"] + " " + sdr["name"] + " " + sdr["type"] + " " + sdr["tarrif"] + " " + sdr["validity"] + " " + sdr["rental"]); // Displaying Record  
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
        public void RemovePlan(int id)
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Database=DispurWireless; integrated security=SSPI");
                // writing sql query  
                SqlCommand cm = new SqlCommand
                    ("Delete from TarrifPlan where planId = '"+id+"'", con);
                // Opening Connection 
                con.Open();
                // Executing the SQL query  
                int i = cm.ExecuteNonQuery();
                // Displaying a message  
                if (i > 0)
                {
                    Console.WriteLine("Record deleted Successfully");
                } else
                {
                    Console.WriteLine("Plan ID not found");
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
        public void UpdateTarrif(int id,int newRate)
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Database=DispurWireless; integrated security=SSPI");
                // writing sql query  
                SqlCommand cm = new SqlCommand
                    ("Update TarrifPlan Set tarrif = '"+newRate+"'" + "where planId = '" + id + "'", con);
                // Opening Connection 
                con.Open();
                // Executing the SQL query  
                int i = cm.ExecuteNonQuery();
                // Displaying a message  
                if (i > 0)
                {
                    Console.WriteLine("Record Successfully updated");
                }
                else
                {
                    Console.WriteLine("Plan ID not found");
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
