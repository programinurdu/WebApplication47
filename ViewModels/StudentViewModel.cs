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

        public void UpdateStudent(Student student)
        {
            using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_StudentsUpdateStudent", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();


                    cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                    cmd.Parameters.AddWithValue("@FullName", student.FullName);
                    cmd.Parameters.AddWithValue("@Email", student.Email);
                    cmd.Parameters.AddWithValue("@Mobile", student.Mobile);
                    cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Notes", student.Notes);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Create
        public void AddStudent(Student student)
        {
            using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_StudentsAddStudent", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();

                    cmd.Parameters.AddWithValue("@FullName", student.FullName);
                    cmd.Parameters.AddWithValue("@Email", student.Email);
                    cmd.Parameters.AddWithValue("@Mobile", student.Mobile);
                    cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Notes", student.Notes);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Reload / Read
        public Student GetStudentByStudentId(int studentId)
        {
            Student student = new Student();

            using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_StudentsGetStudentByStudentId", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();

                    cmd.Parameters.AddWithValue("@StudentId", studentId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();

                    student.StudentId = Convert.ToInt32(reader["StudentId"]);
                    student.FullName = reader["FullName"].ToString();
                    student.Email = reader["Email"].ToString();
                    student.Mobile = reader["Mobile"].ToString();
                    student.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    student.Notes = reader["Notes"].ToString();
                }
            }


            return student;
        }

        public void DeleteStudent(int studentId)
        {
            using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_StudentsDeleteStudent", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();

                    cmd.Parameters.AddWithValue("@StudentId", studentId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
