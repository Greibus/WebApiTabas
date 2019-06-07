using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TEST.Models;

namespace TEST.Repositories
{
    public class CreateMaletaRepository
    {

        public static bool addMaletaDB(CreateMaleta maleta)
        {
            //string connString = "Server={0}; User Id={1}; Database={2}; Port={3}; Password={4};SSLMode=Prefer";
            string connString = "Server=tabasserver.postgres.database.azure.com; User Id=chanchus@tabasserver; Database=TabasDB; Port=5432; Password=Password1;SSLMode=Prefer";

            using (var conn = new NpgsqlConnection(connString))
            {

                Console.Out.WriteLine("Opening connection");
                conn.Open();

                using (var command = new NpgsqlCommand("INSERT INTO maleta(numero, bagcartid, pasajeroid, costo, revisado, peso) VALUES(@numero, @bagcartid, @pasajeroid, @costo, @revisado, @peso) ", conn))
                {
                    command.Parameters.AddWithValue("@numero", maleta.tnumero);
                    command.Parameters.AddWithValue("@bagcartid", maleta.tbagcartid);
                    command.Parameters.AddWithValue("@pasajeroid", maleta.tpasajeroid);
                    command.Parameters.AddWithValue("@costo", maleta.tcosto);
                    command.Parameters.AddWithValue("@revisado", maleta.trevisado);
                    command.Parameters.AddWithValue("@peso", maleta.tpeso);


                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows updated={0}", nRows));

                    return true;
                }
            }



        }


        public static List<CreateMaleta> GetAllMaleta()
        {
            string connString = "Server=tabasserver.postgres.database.azure.com; User Id=chanchus@tabasserver; Database=TabasDB; Port=5432; Password=Password1;SSLMode=Prefer";

            using (var conn = new NpgsqlConnection(connString))
            {

                Console.Out.WriteLine("Opening connection");
                conn.Open();

                using (var command = new NpgsqlCommand("SELECT * FROM maleta", conn))
                {
                    var reader = command.ExecuteReader();
                    List<CreateMaleta> listamaleta = new List<CreateMaleta>();

                    while (reader.Read())
                    {
                        CreateMaleta maleta = null;
                        maleta = new CreateMaleta();
                        maleta.tnumero = Convert.ToInt32(reader.GetValue(0));
                        maleta.tbagcartid = reader.GetValue(1).ToString();
                        maleta.tpasajeroid = reader.GetValue(2).ToString();
                        maleta.tcosto = Convert.ToInt32(reader.GetValue(2));
                        maleta.trevisado = Convert.ToBoolean(reader.GetValue(2));
                        maleta.tpeso = Convert.ToInt32(reader.GetValue(2));
                        listamaleta.Add(maleta);
                    }

                    return listamaleta;



                }

            }

        }

        public static List<CreateMaleta> GetMaleta(int numero)
        {
            string connString = "Server=tabasserver.postgres.database.azure.com; User Id=chanchus@tabasserver; Database=TabasDB; Port=5432; Password=Password1;SSLMode=Prefer";

            using (var conn = new NpgsqlConnection(connString))
            {

                Console.Out.WriteLine("Opening connection");
                conn.Open();

                string query = "SELECT * FROM maleta WHERE numero='@numero'";

                query = query.Replace("@numero", numero.ToString());


                using (var command = new NpgsqlCommand(query, conn))
                {

                    var reader = command.ExecuteReader();
                    List<CreateMaleta> listamaleta = new List<CreateMaleta>();

                    while (reader.Read())
                    {
                        CreateMaleta maleta = null;
                        maleta = new CreateMaleta();
                        maleta.tnumero = Convert.ToInt32(reader.GetValue(0));
                        maleta.tbagcartid = reader.GetValue(1).ToString();
                        maleta.tpasajeroid = reader.GetValue(2).ToString();
                        maleta.tcosto = Convert.ToInt32(reader.GetValue(2));
                        maleta.trevisado = Convert.ToBoolean(reader.GetValue(2));
                        maleta.tpeso = Convert.ToInt32(reader.GetValue(2));
                        listamaleta.Add(maleta);
                    }

                    return listamaleta;



                }
            }



        }


        public static bool deleteMaleta(int numero)
        {
            string connString = "Server=tabasserver.postgres.database.azure.com; User Id=chanchus@tabasserver; Database=TabasDB; Port=5432; Password=Password1;SSLMode=Prefer";


            using (var conn = new NpgsqlConnection(connString))
            {
                Console.Out.WriteLine("Opening connection");
                conn.Open();

                string query = "DELETE FROM avion WHERE numero='@numero'";

                query = query.Replace("@numero", numero.ToString());

                using (var command = new NpgsqlCommand(query, conn))
                {
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows deleted={0}", nRows));

                    return true;
                }
            }


        }


    }//////////////////



}/////////////////