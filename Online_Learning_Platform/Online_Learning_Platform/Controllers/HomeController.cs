using Microsoft.AspNetCore.Mvc;
using Online_Learning_Platform.Models;
using System.Diagnostics;

namespace Online_Learning_Platform.Controllers
{
    public class HomeController : Controller
    {
       
        //Homepage
        public IActionResult Index()
        {
            return View();
        }

        //Login
        public IActionResult Login()
        {
            return View();
        }

        //Registration
        public IActionResult Registration()
        {
            return View();
        }

        //Courses
        public IActionResult Courses()
        {
            return View();
        }

        //Course Details
        public IActionResult CourseDetails()
        {
            return View();
        }

        //Contact Details
        public IActionResult Contact()
        {
            return View();
        }

        //Forget Password
        public IActionResult ForgetPassword()
        {
            return View();
        }

    }
}