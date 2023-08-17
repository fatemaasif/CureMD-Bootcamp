using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;

namespace ToDoListAPI.Controllers
{
    public class TaskController : ApiController
    {
        private readonly Configuration _configuration;
        public TaskController(Configuration config)
        {
            _configuration = config;
        }

        
        [HttpGet]
        [Route("GetTasks")]
        public string GetAllTasks()
        {
            return "hello";
        }
        //public List<Task> GetAllTasks()
        //{
        //    List<Task> tasks = new List<Task>();
        //    return tasks;
        //}

        //[HttpGet]
        //public Task GetTask(string taskTitle)
        //{
        //    Task task = new Task();
        //    return task;
        //}

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
