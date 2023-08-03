using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Students.Data_Layer
{
    public class DataLayer
    {
        string connString = "";

        public DataLayer()
        {
            connString = ConfigurationManager.ConnectionStrings["StudentsConnection"].ConnectionString;
        }

        public DataTable GetListofStudents()
        {
            try
            {
                List <Student> listOfStudents = new List<Student>();
                DataTable dataTable = new DataTable();
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand("GetAllStudents", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);

                    connection.Close();
                }
                return dataTable;
            }
            catch (Exception exception)
            {

                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetAllStudents due to "
                   + exception.Message, exception.InnerException); ;
            }
        }





    }

    
}
