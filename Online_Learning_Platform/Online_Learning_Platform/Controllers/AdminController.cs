using Microsoft.AspNetCore.Mvc;

namespace Online_Learning_Platform.Controllers
{
    public class AdminController : Controller
    {

        //Add Course
        public IActionResult AddCourse()
        {
            return View();
        }


        //Admin Dashboard
        public IActionResult AdminDashboard()
        {
            return View();
        }

        //Add Webinar
        public IActionResult AddWebinar()
        {
            return View();
        }

        //Contact Feeback
        public IActionResult ContactFeedback()
        {
            return View();
        }

    }
}
