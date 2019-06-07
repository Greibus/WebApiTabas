using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TEST.Models;

namespace TEST.Repositories
{
    public class CreateVueloRepository
    {
        public static bool addVueloDB(CreateVuelo vuelo)
        {
            //string connString = "Server={0}; User Id={1}; Database={2}; Port={3}; Password={4};SSLMode=Prefer";
            string connString = "Server=tabasserver.postgres.database.azure.com; User Id=chanchus@tabasserver; Database=TabasDB; Port=5432; Password=Password1;SSLMode=Prefer";

            using (var conn = new NpgsqlConnection(connString))
            {

                Console.Out.WriteLine("Opening connection");
                conn.Open();

                using (var command = new NpgsqlCommand("INSERT INTO vuelo(id, precio) VALUES(@tid, @tprecio)", conn))
                {
                    command.Parameters.AddWithValue("@tid", vuelo.tid);
                    command.Parameters.AddWithValue("@tprecio", vuelo.tprecio);

                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows updated={0}", nRows));

                    return true;
                }
            }



        }

        public static List<CreateVuelo> GetAllVuelo()
        {
            string connString = "Server=tabasserver.postgres.database.azure.com; User Id=chanchus@tabasserver; Database=TabasDB; Port=5432; Password=Password1;SSLMode=Prefer";

            using (var conn = new NpgsqlConnection(connString))
            {

                Console.Out.WriteLine("Opening connection");
                conn.Open();

                using (var command = new NpgsqlCommand("SELECT * FROM vuelo", conn))
                {
                    var reader = command.ExecuteReader();
                    List<CreateVuelo> listavuelo = new List<CreateVuelo>();

                    while (reader.Read())
                    {
                        CreateVuelo vuelo = null;
                        vuelo = new CreateVuelo();
                        vuelo.tid = reader.GetValue(0).ToString();
                        vuelo.tprecio = Convert.ToInt32(reader.GetValue(1));
                        listavuelo.Add(vuelo);
                    }

                    return listavuelo;

                }

            }

        }


        public static List<CreateVuelo> GetVuelo(int id)
        {
            string connString = "Server=tabasserver.postgres.database.azure.com; User Id=chanchus@tabasserver; Database=TabasDB; Port=5432; Password=Password1;SSLMode=Prefer";

            using (var conn = new NpgsqlConnection(connString))
            {

                Console.Out.WriteLine("Opening connection");
                conn.Open();

                string query = "SELECT * FROM vuelo WHERE id='@id'";

                query = query.Replace("@id", id.ToString());


                using (var command = new NpgsqlCommand(query, conn))
                {

                    var reader = command.ExecuteReader();
                    List<CreateVuelo> listavuelo = new List<CreateVuelo>();

                    while (reader.Read())
                    {
                        CreateVuelo vuelo = null;
                        vuelo = new CreateVuelo();
                        vuelo.tid = reader.GetValue(0).ToString();
                        vuelo.tprecio = Convert.ToInt32(reader.GetValue(1));
                        listavuelo.Add(vuelo);
                    }

                    return listavuelo;



                }
            }



        }


        public static bool deleteVuelo(int id)
        {
            string connString = "Server=tabasserver.postgres.database.azure.com; User Id=chanchus@tabasserver; Database=TabasDB; Port=5432; Password=Password1;SSLMode=Prefer";


            using (var conn = new NpgsqlConnection(connString))
            {
                Console.Out.WriteLine("Opening connection");
                conn.Open();

                string query = "DELETE FROM vuelo WHERE id='@id'";

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




    } ///////
}