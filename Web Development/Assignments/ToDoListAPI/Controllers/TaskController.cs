using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using ToDoListAPI.Business_Layer;
using ToDoListAPI.Models;

namespace ToDoListAPI.Controllers
{
    public class TaskController : ApiController
    {
        public BusinessLayer dataLayer = new BusinessLayer();
        [HttpGet]
        [Route("GetTasks")]
        public List<Task> GetAllTasks()
        {
            try
            {
                List<Task> tasks = new List<Task>();
                tasks = dataLayer.GetAllTasks();
                return tasks;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetAllTasks in Controller due to "
                   + exception.Message, exception.InnerException);
            }
        }

        [HttpGet]
        [Route("GetTask/{taskTitle}")]
        public Task GetTask(string taskTitle)
        {
            try
            {
                Task task = dataLayer.GetTask(taskTitle);
                return task;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetTask in Controller due to "
                   + exception.Message, exception.InnerException);
            }
            
        }

        [HttpPost]
        public void AddTask(string tasktitle, int timeToCompletion=-1, string taskCategory="")
        {

        }

        [HttpPut]
        public void UpdateTask(string newTaskTitle, string taskTitle)
        {

        }

        [HttpDelete]
        public void DeleteTask(string taskTitle)
        {

        }
    }
}
