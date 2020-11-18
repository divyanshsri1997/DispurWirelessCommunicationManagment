using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DispurWirelessCommunicationManagment
{
    class TariffPlanPortal
    {
        static void Main(String[] args)
        {

            Console.WriteLine("Tariff Plan Management Portal");

            Console.WriteLine("1.Admin \n 2.User");

            int i1 = Convert.ToInt32(Console.ReadLine());

            if (i1 == 1)
            {
                // For admin
                //Validate admin with login credentials

                Console.WriteLine("1.Add plan \n 2.Update plan \n 3.Delete plan");

                int i2 = Convert.ToInt32(Console.ReadLine());

                if (i2 == 1)
                {
                    TariffPlanPortal.TariffPlanInsert();
                }
                else if (i2 == 2)
                {
                    TariffPlanPortal.UpdateTariffPlanInsert();
                }
                else if (i2 == 3)
                {
                    TariffPlanPortal.DeleteTariffPlanDetails();
                }

            }
            else
            {
                // For user 

                Console.WriteLine("1. Plan Details");

                TariffPlanPortal.ShowTariffPlanDetails();

            }

        }




        public static void TariffPlanInsert()
        {
            SqlConnection con = null;

            Console.WriteLine("Enter Name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Type : ");
            string type = Console.ReadLine();
            Console.WriteLine("Enter Tariff : ");
            int tariff = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Validity : ");
            int validity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Rental : ");
            int rental = Convert.ToInt32(Console.ReadLine());


            int id1 = Globals2.id++;


            try
            {
                // Creating Connection  
                con = new SqlConnection("data source=(localdb)\\MSSQLLocalDB; database=Customer Management Portal; integrated security=SSPI");
                // writing sql query  

                string query1 = "insert dbo.TariffPlan(planId,name,type,tariff,validity,rental) values(@id,@name,@type,@tariff,@validity,@rental)";


                SqlCommand cm = new SqlCommand(query1, con);

                cm.Parameters.AddWithValue("@id", id1);
                cm.Parameters.AddWithValue("@name", name);
                cm.Parameters.AddWithValue("@type", type);
                cm.Parameters.AddWithValue("@tariff", tariff);
                cm.Parameters.AddWithValue("@validity", validity);
                cm.Parameters.AddWithValue("@rental", rental);


                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                int i = cm.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Record Inserted Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }




        public static void ShowTariffPlanDetails()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=(localdb)\\MSSQLLocalDB; database=Customer Management Portal; integrated security=SSPI");

                SqlCommand cm = new SqlCommand("Select * from TariffPlan", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();
                // Iterating Data  
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["planid"] + " " + sdr["name"] + " " + sdr["type"] + " " + sdr["tariff"] + " " + sdr["validity"] + " " + sdr["rental"]); // Displaying Record  
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            finally
            {
                con.Close();
            }

        }



        public static void UpdateTariffPlanInsert()
        {
            SqlConnection con = null;



            Console.WriteLine("Enter id of plan : ");
            int id = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Enter Tariff : ");
            int tariff = Convert.ToInt32(Console.ReadLine());

            try
            {
                // Creating Connection  
                con = new SqlConnection("data source=(localdb)\\MSSQLLocalDB; database=Customer Management Portal; integrated security=SSPI");
                // writing sql query  

                string query1 = "update dbo.TariffPlan set tariff=@tariff where planid = @id";


                SqlCommand cm = new SqlCommand(query1, con);

                cm.Parameters.AddWithValue("@id", id);

                cm.Parameters.AddWithValue("@tariff", tariff);



                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                int i = cm.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Record updated Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }

        }



        public static void DeleteTariffPlanDetails()
        {
            SqlConnection con = null;
            try
            {

                Console.WriteLine("Enter plan id : ");
                int id = Convert.ToInt32(Console.ReadLine());


                con = new SqlConnection("data source=(localdb)\\MSSQLLocalDB; database=Customer Management Portal; integrated security=SSPI");

                // writing sql query  

                string query = "delete from Tariffplan where planId = @id";

                SqlCommand cm = new SqlCommand(query, con);

                cm.Parameters.AddWithValue("@id", id);

                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
                Console.WriteLine("Record Deleted Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            finally
            {
                con.Close();
            }

        }


    }


    public static class Globals2
    {
        public static int id = 10000;
    }
}
