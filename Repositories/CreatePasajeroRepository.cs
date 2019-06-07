using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TEST.Models;

namespace TEST.Repositories
{
    public class CreatePasajeroRepository
    {
        public static bool addPasajeroToDB(CreatePasajero pasajero)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            var query = "INSERT INTO Pasajero (Pasaporte, Carne, Nombre, Telefono, NTarjeta, Pass) VALUES ('@Pasaporte', @Carne, '@Nombre', @Telefono, '@NTarjeta', @Pass)";

            query = query.Replace("@Pasaporte", pasajero.tpasaporte)
                    .Replace("@Carne", pasajero.tcarne)
                    .Replace("@Nombre", pasajero.tnomb)
                    .Replace("@Telefono", pasajero.ttelfono)
                    .Replace("@NTarjeta", pasajero.tntarjeta)
                    .Replace("@Pass", pasajero.tpass);



            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static CreatePasajero getPasajeroFromDB(string pasaporte)
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Pasajero WHERE Pasaporte='@pasaporte'";

            query = query.Replace("@pasaporte", pasaporte);

            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            CreatePasajero pasajero = null;
            while (reader.Read())
            {
                pasajero = new CreatePasajero();
                pasajero.tpasaporte = reader.GetValue(0).ToString();
                pasajero.tcarne = reader.GetValue(1).ToString();
                pasajero.tnomb = reader.GetValue(2).ToString();
                pasajero.ttelfono = reader.GetValue(3).ToString();
                pasajero.tntarjeta = reader.GetValue(4).ToString();
                pasajero.tpass = reader.GetValue(5).ToString();
            }
            connection.Close();
            return pasajero;
        }

        public static List<CreatePasajero> getAllPasajeroFromDB()
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Pasajero";



            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            List<CreatePasajero> listaPasajero = new List<CreatePasajero>();
            CreatePasajero pasajero = null;
            while (reader.Read())
            {
                pasajero = new CreatePasajero();
                pasajero.tpasaporte = reader.GetValue(0).ToString();
                pasajero.tcarne = reader.GetValue(1).ToString();
                pasajero.tnomb = reader.GetValue(2).ToString();
                pasajero.ttelfono = reader.GetValue(3).ToString();
                pasajero.tntarjeta = reader.GetValue(4).ToString();
                pasajero.tpass = reader.GetValue(5).ToString();
                listaPasajero.Add(pasajero);
            }
            connection.Close();
            return listaPasajero;
        }
        public static bool deletePasajeroFromDB(string pasaporte)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";


            var query = "DELETE  FROM Pasajero WHERE Pasaporte='@pasaporte'";

            query = query.Replace("@pasaporte", pasaporte);


            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    


    }////////////


}/////