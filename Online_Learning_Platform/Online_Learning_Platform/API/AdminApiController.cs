using DataBase_Access.Helper;
using DataBase_Access.IRepository;
using DataBase_Access.Mappers.UIMapper.Model;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Learning_Platform.Mappers.UIMapper.Model;

namespace Online_Learning_Platform.API
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class AdminApiController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IHelper _helper;

        public AdminApiController(IAdminRepository adminRepository,IHelper helper)
        {
            _adminRepository = adminRepository;
            _helper = helper;
        }


        //Fetch All Users
        [HttpGet]
        public IEnumerable<Registration> GetUsers()
        {
            return _adminRepository.GetRegistrations();
        }


        //Add Courses
        [HttpPost]
        public void AddCourse(Course course)
        {
            _adminRepository.AddCourses(course);
        }

        //Get Courses
        [HttpGet]
        public IEnumerable<Course> FetchCourses()
        {
            return _adminRepository.GetCourses();
        }


        //Get All Webinars
        public IEnumerable<Webinar> FetchWebinar()
        {
            return _adminRepository.GetWebinar();
        }



        //Add Webinar
        [HttpPost]
        public void AddWebinar(Webinar webinar)
        {
            _adminRepository.AddWebinar(webinar);
        }

        //Get Contact Details
        [HttpGet]
        public IEnumerable<Contact> FetchContactDetails()
        {
            return _adminRepository.GetContact();
        }

        //Reply Back
        [HttpPost]
        public void ReplyBack(string email, string reply)
        {
            _adminRepository.ReplyBack(email, reply);
        }

        //Upload Video
        [HttpPost]
        public async Task Photos(List<IFormFile> files)
        {
            if (files != null && files.Count > 0)
            {
                await _helper.UploadFiles(files);       
            }
        }


    }
}
