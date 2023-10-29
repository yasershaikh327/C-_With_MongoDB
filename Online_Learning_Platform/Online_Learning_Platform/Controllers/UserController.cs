using Microsoft.AspNetCore.Mvc;

namespace Online_Learning_Platform.Controllers
{
    public class UserController : Controller
    {

        //User Dashboard
        public IActionResult UserDashboard()
        {
            return View();
        }


        //User Profile
        public IActionResult UserProfile()
        {
            return View();
        }

        //Logout
        public IActionResult Logout()
        {
            return View();
        }

        //Payment 
        public IActionResult Payment()
        {
            return View();
        }

        //Course
        public IActionResult Courses()
        {
            return View();
        }


        //Course Details
        public IActionResult CourseDetails()
        {
            return View();
        }

      
    }
}
