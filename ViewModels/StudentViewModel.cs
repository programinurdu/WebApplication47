using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication47.Models;
using WebApplication47.Models.Shared;

namespace WebApplication47.ViewModels
{
    public class StudentViewModel
    {
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_StudentsGetAllStudents", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.StudentId = Convert.ToInt32(reader["StudentId"]);
                        student.FullName = reader["FullName"].ToString();
                        student.Email = reader["Email"].ToString();
                        student.Mobile = reader["Mobile"].ToString();
                        student.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                        student.Notes = reader["Notes"].ToString();

                        students.Add(student);
                    }
                }
            }

            return students;
        }
    }
}
