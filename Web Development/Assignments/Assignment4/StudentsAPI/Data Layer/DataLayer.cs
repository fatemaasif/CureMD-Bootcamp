using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using StudentsAPI.Models;

namespace StudentsAPI.Data_Layer
{
    public class DataLayer
    {
        string connString = "";

        public DataLayer()
        {
            connString = ConfigurationManager.ConnectionStrings["StudentsConnection"].ConnectionString;
        }
        public bool TestConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while testing the connection: " + ex.Message);
                return false;
            }
        }
        public DataTable GetListofStudents()
        {
            try
            {
                List<Student> listOfStudents = new List<Student>();
                DataTable dataTable = new DataTable();
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand("GetAllStudents", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);

                    System.Diagnostics.Debug.WriteLine("Data Layer operation done");

                    connection.Close();
                }
                return dataTable;
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine("data layer operation unsuccessful");
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetAllStudents due to "
                   + exception.Message, exception.InnerException); ;
            }
        }
    }
}