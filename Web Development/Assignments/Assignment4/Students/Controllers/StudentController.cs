using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Students.Business_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Controllers
{
    //[ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
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
    }
}
