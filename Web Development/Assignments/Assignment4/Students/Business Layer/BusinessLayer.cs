using Students.Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;

namespace Students.Business_Layer
{
    public class BusinessLayer
    {
        public DataLayer dataLayer = new DataLayer();

        public List<Student> GetListofStudents()
        {
            try
            {
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
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetListOfStudents due to "
                   + exception.Message, exception.InnerException);
            }
        }

    }
}
