using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TEST.Models;

namespace TEST.Repositories
{
    public class CreateEmpleadoRepository
    {


        public static bool addClienteToDB(CreateEmpleado empleado)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            var query = "INSERT INTO Empleado (Cedula, RolN, Pnombre, Apellidos, Usuario, Pass) VALUES ('@Cedula', @RolN, '@Pnombre', @Apellidos, '@Usuario', @Pass)";

            query = query.Replace("@Cedula", empleado.tced)
                    .Replace("@RolN", empleado.trol.ToString())
                    .Replace("@Pnombre", empleado.tnomb)
                    .Replace("@Apellidos", empleado.tape)
                    .Replace("@Usuario", empleado.tuser)
                    .Replace("@Pass", empleado.tpass);



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

        public static CreateEmpleado getEmpleadoFromDB(string user)
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Empleado WHERE Usuario='@user'";

            query = query.Replace("@user", user);

            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            CreateEmpleado empleado = null;
            while (reader.Read())
            {
                empleado = new CreateEmpleado();
                empleado.tced = reader.GetValue(0).ToString();
                empleado.trol = Convert.ToInt32(reader.GetValue(1));
                empleado.tnomb= reader.GetValue(2).ToString();
                empleado.tape = reader.GetValue(3).ToString();
                empleado.tuser = reader.GetValue(4).ToString();
                empleado.tpass = reader.GetValue(5).ToString();
            }
            connection.Close();
            return empleado;
        }




        public static List<CreateEmpleado> getAllEmpeladoFromDB()
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Empleado";



            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            List<CreateEmpleado> listaEmpleado = new List<CreateEmpleado>();

            while (reader.Read())
            {
                CreateEmpleado empleado = null;
                empleado.tced = reader.GetValue(0).ToString();
                empleado.trol = Convert.ToInt32(reader.GetValue(1));
                empleado.tnomb = reader.GetValue(2).ToString();
                empleado.tape = reader.GetValue(3).ToString();
                empleado.tuser = reader.GetValue(4).ToString();
                empleado.tpass = reader.GetValue(5).ToString();
                listaEmpleado.Add(empleado);
            }
            connection.Close();
            return listaEmpleado;
        }



        public static bool deleteEmpleadoFromDB(string user)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";


            var query = "DELETE  FROM Empleado WHERE Usuario='@user'";

            query = query.Replace("@user", user);


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

    }


}