using System;
using System.Collections.Generic;
using System.Data;
using ToDoListAPI.Models;
using ToDoListAPI.Data_Layer;

namespace ToDoListAPI.Business_Layer
{
    public class BusinessLayer
    {
        public DataLayer DL = new DataLayer();
        public List<Task> GetAllTasks()
        {
            try
            {
                DataTable table = new DataTable();
                List<Task> taskList = new List<Task>();
                table = DL.GetListofTasks();
                if (table!=null && table.Rows.Count>0)
                {
                    foreach (DataRow dataRow in table.Rows)
                    {
                        Task task = new Task();
                        task.title = dataRow["TaskTitle"].ToString();
                        task.completed = Convert.ToBoolean(dataRow["Completed"]);
                        task.timeToCompletion = Convert.ToInt32(dataRow["TimeToCompletion"]);
                        task.editMode = Convert.ToBoolean(dataRow["EditMode"]);
                        task.taskCategory = dataRow["TaskCategory"].ToString();
                    }
                }
                return taskList;
            }
            catch (Exception exception)
            {

                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetAllTasks in Business Layer due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public Task GetTask(string taskTitle)
        {
            try
            {
                List<Task> tasks = new List<Task>();
                tasks = this.GetAllTasks();
                Task task = tasks.Find(x => x.title == taskTitle);
                return task;
            }
            catch (Exception exception)
            {

                throw new Exception($"An exceptin of type {exception.GetType().ToString()} is encountered" +
                    $"in GetTask(Controller) due to {exception.Message} {exception.InnerException}");
            }
        }

    }
}