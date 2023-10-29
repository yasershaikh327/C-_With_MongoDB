using DataBase_Access.IRepository;
using DataBase_Access.Mappers.DToMapper.Model;
using DataBase_Access.Mappers.UIMapper.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Learning_Platform.Mappers.UIMapper.Model;

namespace Online_Learning_Platform.API
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class UserApiController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserApiController(IUserRepository userRepository) { 
            _userRepository = userRepository;
        }


        //Book Course
        [HttpPost]
        public bool BookCourse(CourseBook courseBook)
        {
            if(_userRepository.CheckIfCourseisBooked(courseBook)) 
                return _userRepository.BookCourse(courseBook);
            return false;
        }


        //Check if Course is Booked
        public bool CheckIfCourseIsBooked(CourseBook courseBook)
        {
            return _userRepository.CheckIfCourseisBooked(courseBook);
        }


        //Get Booking Details
        [HttpGet]
        public IEnumerable<CourseBook> FetchBookingDetails()
        {
            return _userRepository.GetBookingDetails();
        }

        //Get Booking Details
        [HttpGet]
        public IEnumerable<CourseBook> FetchUserBookingDetails(string email)
        {
            return _userRepository.GetUserDetails(email);
        }



        //Check if Old Password is Correct 
        [HttpPost]
        public bool UpdatePassword(UpdatePassword updatepassword)
        {
            if (_userRepository.OldPassword(updatepassword))
                return _userRepository.Updatepassword(updatepassword);
            return false;
        }
    }
}
