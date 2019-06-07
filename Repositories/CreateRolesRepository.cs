using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TEST.Models;


namespace TEST.Repositories
{
    public class CreateRolesRepository
    {

        public static bool addRolesDB(CreateRoles rol)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            var query = "INSERT INTO Rol (Numero, Rol) VALUES ('@Numero', @Rol)";

            query = query.Replace("@Numero", rol.tnumero.ToString())
                    .Replace("@Rol", rol.trol);
                    



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


        public static CreateRoles getRolesFromDB(int numero)
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Rol WHERE Numero='@numero'";

            query = query.Replace("@numero", numero.ToString());

            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            CreateRoles roles = null;
            while (reader.Read())
            {
                roles = new CreateRoles();
                roles.tnumero = Convert.ToInt32(reader.GetValue(0));
                roles.trol = reader.GetValue(1).ToString();
            }
            connection.Close();
            return roles;
        }


        public static List<CreateRoles> getAllRolesFromDB()
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Rol";



            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            List<CreateRoles> listaRol = new List<CreateRoles>();
            CreateRoles roles = null;
            while (reader.Read())
            {
                roles = new CreateRoles();
                roles.tnumero = Convert.ToInt32(reader.GetValue(0));
                roles.trol = reader.GetValue(1).ToString();
                listaRol.Add(roles);
            }
            connection.Close();
            return listaRol;
        }

        public static bool deleteRolesFromDB(int numero)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";


            var query = "DELETE  FROM Rol WHERE Numero='@numero'";

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



    }//////////////////
}