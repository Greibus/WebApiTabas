using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TEST.Models;

namespace TEST.Repositories
{
    public class CreateMarcaRepository
    {
        public static bool addMarca(CreateMarca marca)
        {

            string connString = "Server=tabasserver.postgres.database.azure.com; User Id=chanchus@tabasserver; Database=TabasDB; Port=5432; Password=Password1;SSLMode=Prefer";


            using (var conn = new NpgsqlConnection(connString))
            {

                Console.Out.WriteLine("Opening connection");
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT CreateMarca(@Tmarca, @TModelo, @TCapacidad)", conn))
                {

                    command.Parameters.AddWithValue("@TMarca", marca.tmarca);
                    command.Parameters.AddWithValue("@TModelo", marca.tmodelo);
                    command.Parameters.AddWithValue("@TCapacidad", marca.tcapacidad);


                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows updated={0}", nRows));

                    return true;
                }
            }

        }

        public static List<CreateMarca> GetAllMarca()
        {
            string connString = "Server=tabasserver.postgres.database.azure.com; User Id=chanchus@tabasserver; Database=TabasDB; Port=5432; Password=Password1;SSLMode=Prefer";

            using (var conn = new NpgsqlConnection(connString))
            {

                Console.Out.WriteLine("Opening connection");
                conn.Open();

                using (var command = new NpgsqlCommand("SELECT * FROM marcabagcart", conn))
                {
                    var reader = command.ExecuteReader();
                    List<CreateMarca> listamarca = new List<CreateMarca>();

                    while (reader.Read())
                    {
                        CreateMarca marca = null;
                        marca = new CreateMarca();
                        marca.tmarca = reader.GetValue(0).ToString();
                        marca.tmodelo = Convert.ToInt32(reader.GetValue(1));
                        marca.tcapacidad = Convert.ToInt32(reader.GetValue(2));
                        listamarca.Add(marca);
                    }

                    return listamarca;



                }

            }

        }

        public static List<CreateMarca> GetMarca(int id)
        {
            string connString = "Server=tabasserver.postgres.database.azure.com; User Id=chanchus@tabasserver; Database=TabasDB; Port=5432; Password=Password1;SSLMode=Prefer";

            using (var conn = new NpgsqlConnection(connString))
            {

                Console.Out.WriteLine("Opening connection");
                conn.Open();

                string query = "SELECT * FROM marcabagcart WHERE id='@id'";

                query = query.Replace("@id", id.ToString());


                using (var command = new NpgsqlCommand(query, conn))
                {

                    var reader = command.ExecuteReader();
                    List<CreateMarca> listamarca = new List<CreateMarca>();

                    while (reader.Read())
                    {
                        CreateMarca marca = null;
                        marca = new CreateMarca();
                        marca.tmarca = reader.GetValue(0).ToString();
                        marca.tmodelo = Convert.ToInt32(reader.GetValue(1));
                        marca.tcapacidad = Convert.ToInt32(reader.GetValue(2));
                        listamarca.Add(marca);
                    }

                    return listamarca;



                }
            }



        }


        public static bool deleteMarca(int id)
        {
            string connString = "Server=tabasserver.postgres.database.azure.com; User Id=chanchus@tabasserver; Database=TabasDB; Port=5432; Password=Password1;SSLMode=Prefer";


            using (var conn = new NpgsqlConnection(connString))
            {
                Console.Out.WriteLine("Opening connection");
                conn.Open();

                string query = "DELETE FROM marcabagcart WHERE id='@id'";

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