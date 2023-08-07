using StudentsAPI.Business_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentsAPI.Models;

namespace StudentsAPI.Controllers
{
    [Route("Student")]
    public class StudentController : ApiController
    {
        public BusinessLayer dataLayer = new BusinessLayer();
        [HttpGet]
        public List<Student> GetListOfStudents()
        {
            try
            {
                List<Student> students = new List<Student>();
                students = dataLayer.GetListofStudents();
                return students;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetListOfStudents due to "
                   + exception.Message, exception.InnerException);
            }
        }

        [Route("Student/{studentID}")]
        [HttpGet]
        public Student GetStudent(int studentID)
        {
            try
            {
                Student student = new Student();
                student = dataLayer.GetStudent(studentID);
                return student;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetListOfStudents due to "
                   + exception.Message, exception.InnerException);
            }
        }
    }
}