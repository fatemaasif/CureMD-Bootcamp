using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using ToDoListAPI.Models;

namespace ToDoListAPI.Data_Layer
{
    public class DataLayer
    {
        string _connString = "";
        public DataLayer()
        {
            _connString = WebConfigurationManager.ConnectionStrings["ConnectionStringToDoManager"].ConnectionString;
        }
        public DataTable GetListofTasks()
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (SqlConnection con = new SqlConnection(_connString))
                {
                    SqlCommand command = new SqlCommand("GetAllTasks", con);
                    command.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);
                    con.Close();
                }
                return dataTable;
            }
            catch (Exception exception)
            {

                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetAllTasks due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public void AddTaskinDB(Task task)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connString))
                {
                    SqlCommand command = new SqlCommand("AddTask", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TaskTitle", task.title);
                    command.Parameters.AddWithValue("@TimeToCompletion", task.timeToCompletion);
                    command.Parameters.AddWithValue("@TaskCategory", task.taskCategory);

                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception exception)
            {

                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in AddTaskinDB due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public void UpdateTaskinDB(string newTaskTitle, string taskTitle)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connString))
                {
                    SqlCommand command = new SqlCommand("UpdateTask", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NewTaskTitle", newTaskTitle);
                    command.Parameters.AddWithValue("@TaskTitle", taskTitle);

                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception exception)
            {

                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in UpdateTaskinDB due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public void DeleteTaskinDB(string taskTitle)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connString))
                {
                    SqlCommand command = new SqlCommand("DeleteTask", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TaskTitle", taskTitle);

                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception exception)
            {

                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in DeleteTaskinDB due to "
                   + exception.Message, exception.InnerException);
            }
        }

    }

}