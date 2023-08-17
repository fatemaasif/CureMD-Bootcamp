using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoListAPI.Models
{
    public class Task
    {
        public string title { get; set; }
        public bool completed { get; set; }
        public int timeToCompletion { get; set; }
        public bool editMode { get; set; }
        public string taskCategory { get; set; }
    }
}