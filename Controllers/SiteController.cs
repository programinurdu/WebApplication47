using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication47.Models;
using WebApplication47.ViewModels;

namespace WebApplication47.Controllers
{
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            StudentViewModel svm = new StudentViewModel();
            List<Student> students = svm.GetAllStudents();
            return View(students);
        }

        public IActionResult StudentInfo(int studentId=0)
        {
            Student student = new Student();

            if (studentId == 0)
            { 
                student.StudentId = 0;            
            }
            else
            {
                StudentViewModel svm = new StudentViewModel();
                student = svm.GetStudentByStudentId(studentId);
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult StudentInfo(Student student)
        {
            if (ModelState.IsValid)
            {
                StudentViewModel svm = new StudentViewModel();

                if (student.StudentId == 0)
                {
                    svm.AddStudent(student);
                }
                else
                {
                    svm.UpdateStudent(student);
                }

                return RedirectToAction("Index", "Site");
            }
            return View();
        }

        public IActionResult DeleteStudent(int studentId = 0)
        {
            StudentViewModel svm = new StudentViewModel();
            svm.DeleteStudent(studentId);

            return RedirectToAction("Index", "Site");
        }
    }
}
