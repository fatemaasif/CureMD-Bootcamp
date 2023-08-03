using StudentsAPI.Data_Layer;
using StudentsAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace StudentsAPI.Business_Layer
{
    public class BusinessLayer
    {
        public DataLayer dataLayer = new DataLayer();

        public List<Student> GetListofStudents()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Succesfully reached business layer");
                DataTable table = new DataTable();
                List<Student> listStudents = new List<Student>();
                table = dataLayer.GetListofStudents();

                if (table != null && table.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in table.Rows)
                    {
                        Student student = new Student();
                        student.ID = Convert.ToInt32(dataRow["ID"]);
                        student.firstName = dataRow["FirstName"].ToString();
                        student.lastName = dataRow["LastName"].ToString();
                        student.age = Convert.ToInt32(dataRow["Age"]);
                        student.course = dataRow["Course"].ToString();
                        listStudents.Add(student);
                    }
                }
                return listStudents;
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine("error in exeuting business layer");
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetListOfStudents due to "
                   + exception.Message, exception.InnerException);
            }
        }

    }

}