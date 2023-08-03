using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsAPI.Models
{
    public class Student
    {
        public int ID { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public int age { get; set; }

        public string course { get; set; }
    }
}