using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TEST.Models;

namespace TEST.Repositories
{
    public class CreateAvionRepository
    {
        public static bool addAvionDB(CreateAvion avion)
        {
            //string connString = "Server={0}; User Id={1}; Database={2}; Port={3}; Password={4};SSLMode=Prefer";
            string connString = "Server=tabasserver.postgres.database.azure.com; User Id=chanchus@tabasserver; Database=TabasDB; Port=5432; Password=Password1;SSLMode=Prefer";

            using (var conn = new NpgsqlConnection(connString))
            {

                Console.Out.WriteLine("Opening connection");
                conn.Open();

                using (var command = new NpgsqlCommand("INSERT INTO avion(id, modelo, capacidad) VALUES(@tid, @tmodelo, @tcapacidad)", conn))
                {
                    command.Parameters.AddWithValue("@tid", avion.tid);
                    command.Parameters.AddWithValue("@tmodelo", avion.tmodelo);
                    command.Parameters.AddWithValue("@tcapacidad", avion.tcapacidad);


                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows updated={0}", nRows));

                    return true;
                }
            }



        }

        public static List<CreateAvion> GetAllAvion()
        {
            string connString = "Server=tabasserver.postgres.database.azure.com; User Id=chanchus@tabasserver; Database=TabasDB; Port=5432; Password=Password1;SSLMode=Prefer";

            using (var conn = new NpgsqlConnection(connString))
            {

                Console.Out.WriteLine("Opening connection");
                conn.Open();

                using (var command = new NpgsqlCommand("SELECT * FROM avion", conn))
                {
                    var reader = command.ExecuteReader();
                    List<CreateAvion> listavion = new List<CreateAvion>();

                    while (reader.Read())
                    {
                        CreateAvion avion = null;
                        avion = new CreateAvion();
                        avion.tid = reader.GetValue(0).ToString();
                        avion.tmodelo = reader.GetValue(1).ToString();
                        avion.tcapacidad = Convert.ToInt32(reader.GetValue(2));
                        listavion.Add(avion);
                    }

                    return listavion;



                }

            }

        }



        public static List<CreateAvion> GetAvion(int id)
        {
            string connString = "Server=tabasserver.postgres.database.azure.com; User Id=chanchus@tabasserver; Database=TabasDB; Port=5432; Password=Password1;SSLMode=Prefer";

            using (var conn = new NpgsqlConnection(connString))
            {

                Console.Out.WriteLine("Opening connection");
                conn.Open();

                string query = "SELECT * FROM avion WHERE id='@id'";

                query = query.Replace("@id", id.ToString());


                using (var command = new NpgsqlCommand(query, conn))
                {

                    var reader = command.ExecuteReader();
                    List<CreateAvion> listavion = new List<CreateAvion>();

                    while (reader.Read())
                    {
                        CreateAvion avion = null;
                        avion = new CreateAvion();
                        avion.tid = reader.GetValue(0).ToString();
                        avion.tmodelo = reader.GetValue(1).ToString();
                        avion.tcapacidad = Convert.ToInt32(reader.GetValue(2));
                        listavion.Add(avion);
                    }

                    return listavion;



                }
            }



        }

        public static bool deleteAvion(int id)
        {
            string connString = "Server=tabasserver.postgres.database.azure.com; User Id=chanchus@tabasserver; Database=TabasDB; Port=5432; Password=Password1;SSLMode=Prefer";


            using (var conn = new NpgsqlConnection(connString))
            {
                Console.Out.WriteLine("Opening connection");
                conn.Open();

                string query = "DELETE FROM avion WHERE id='@id'";

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


    }///////
}