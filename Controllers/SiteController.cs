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
    }
}
