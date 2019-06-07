using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class CreateBagcartRepository
    {

        public static bool addBagcartToDB(CreateBagcart bagcart)
        {
            //string connString = "Server={0}; User Id={1}; Database={2}; Port={3}; Password={4};SSLMode=Prefer";
            string connString = "Server=tabasserver.postgres.database.azure.com; User Id=chanchus@tabasserver; Database=TabasDB; Port=5432; Password=Password1;SSLMode=Prefer";

            using (var conn = new NpgsqlConnection(connString))
            {

                Console.Out.WriteLine("Opening connection");
                conn.Open();

                using (var command = new NpgsqlCommand("SELECT CreateBagcart(@ID, @TMarca, @TModelo)", conn))
                {
                    command.Parameters.AddWithValue("@ID", bagcart.tid);
                    command.Parameters.AddWithValue("@TMarca", bagcart.tmarca);
                    command.Parameters.AddWithValue("@TModelo", bagcart.tmodelo);


                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows updated={0}", nRows));

                    return true;
                }
            }

           

        }

        public static List<CreateBagcart> GetAllBagcart()
        {
            string connString = "Server=tabasserver.postgres.database.azure.com; User Id=chanchus@tabasserver; Database=TabasDB; Port=5432; Password=Password1;SSLMode=Prefer";

            using (var conn = new NpgsqlConnection(connString))
            {

                Console.Out.WriteLine("Opening connection");
                conn.Open();


                using (var command = new NpgsqlCommand("SELECT * FROM bagcart", conn))
                {

                    var reader = command.ExecuteReader();
                    List<CreateBagcart> listabagcart = new List<CreateBagcart>();

                    while (reader.Read())
                    {
                        CreateBagcart bagcart = null;
                        bagcart = new CreateBagcart();
                        bagcart.tid = reader.GetValue(0).ToString();
                        bagcart.tmarca = reader.GetValue(1).ToString();
                        bagcart.tmodelo = Convert.ToInt32(reader.GetValue(2));
                        listabagcart.Add(bagcart);
                    }

                    return listabagcart;



                }
            }



        }



        public static List<CreateBagcart> GetBagcart(int id)
        {
            string connString = "Server=tabasserver.postgres.database.azure.com; User Id=chanchus@tabasserver; Database=TabasDB; Port=5432; Password=Password1;SSLMode=Prefer";

            using (var conn = new NpgsqlConnection(connString))
            {

                Console.Out.WriteLine("Opening connection");
                conn.Open();

                string query = "SELECT * FROM bagcart WHERE id='@id'";

                query = query.Replace("@id", id.ToString());


                using (var command = new NpgsqlCommand(query, conn))
                {

                    var reader = command.ExecuteReader();
                    List<CreateBagcart> listabagcart = new List<CreateBagcart>();

                    while (reader.Read())
                    {
                        CreateBagcart bagcart = null;
                        bagcart = new CreateBagcart();
                        bagcart.tid = reader.GetValue(0).ToString();
                        bagcart.tmarca = reader.GetValue(1).ToString();
                        bagcart.tmodelo = Convert.ToInt32(reader.GetValue(2));
                        listabagcart.Add(bagcart);
                    }

                    return listabagcart;



                }
            }



        }


        public static bool deleteBagcart(int id)
        {
            string connString = "Server=tabasserver.postgres.database.azure.com; User Id=chanchus@tabasserver; Database=TabasDB; Port=5432; Password=Password1;SSLMode=Prefer";


            using (var conn = new NpgsqlConnection(connString))
            {
                Console.Out.WriteLine("Opening connection");
                conn.Open();

                string query = "DELETE FROM bagcart WHERE id='@id'";

                query = query.Replace("@id", id.ToString());

                using (var command = new NpgsqlCommand(query, conn))
                {
                    //command.Parameters.AddWithValue("n", "orange");

                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows deleted={0}", nRows));

                    return true;
                }
            }


        }

    }
}
