using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TEST.Models;

namespace TEST.Repositories
{
    public class CreateUniversidadRepository
    {

        public static bool addUniversidadDB(CreateUniversidad universidad)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            var query = "INSERT INTO Universidad (Numero, Nombre) VALUES ('@Numero', @Nombre)";

            query = query.Replace("@Numero", universidad.tnumero.ToString())
                    .Replace("@Nombre", universidad.tnombre);


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



        public static CreateUniversidad getUniversidadFromDB(int numero)
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Universidad WHERE Numero='@numero'";

            query = query.Replace("@numero", numero.ToString());

            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            CreateUniversidad universidad = null;
            while (reader.Read())
            {
                universidad = new CreateUniversidad();
                universidad.tnumero = Convert.ToInt32(reader.GetValue(0));
                universidad.tnombre = reader.GetValue(1).ToString();
            }
            connection.Close();
            return universidad;
        }



        public static List<CreateUniversidad> getAllUniversidadFromDB()
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Universidad";


            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            List<CreateUniversidad> listaUniversidad = new List<CreateUniversidad>();
            CreateUniversidad universidad = null;
            while (reader.Read())
            {
                universidad = new CreateUniversidad();
                universidad.tnumero = Convert.ToInt32(reader.GetValue(0));
                universidad.tnombre = reader.GetValue(1).ToString();
                listaUniversidad.Add(universidad);
            }
            connection.Close();
            return listaUniversidad;
        }


        public static bool deleteUniversidadFromDB(int numero)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";


            var query = "DELETE  FROM Universidad WHERE Numero='@numero'";

            query = query.Replace("@numero", numero.ToString());


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




    }/////////////
}