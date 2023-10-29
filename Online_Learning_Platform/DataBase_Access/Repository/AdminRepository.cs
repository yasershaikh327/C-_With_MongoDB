using DataBase_Access.DataBase_Management;
using DataBase_Access.Helper;
using DataBase_Access.IRepository;
using DataBase_Access.Mappers.DToMapper.IMapper;
using DataBase_Access.Mappers.UIMapper.IMapper;
using DataBase_Access.Mappers.UIMapper.Model;
using FoodManagement_UI.Services;
using Microsoft.AspNetCore.Http;
using Online_Learning_Platform.Mappers.UIMapper.Model;


namespace DataBase_Access.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly OnlineClassesDB _onlineClassesDB;
        private readonly IRegistrationMapper _registrationMapper;
        private readonly ICourseDtoMapper _courseDtoMapper;
        private readonly ICourseMapper _courseMapper;
        private readonly IHelper _helper;
        private readonly IWebinarMapper _webinarMapper;
        private readonly IWebinarDtoMapper _webinarDtoMapper;
        private readonly IContactMapper _contactMapper;
        private readonly IEmailService _emailService;
        public AdminRepository(OnlineClassesDB onlineClassesDB,IRegistrationMapper registrationMapper,ICourseDtoMapper courseDtoMapper,IHelper helper,ICourseMapper courseMapper,IWebinarMapper webinar,IWebinarDtoMapper webinarDtoMapper,IContactMapper contactMapper,IEmailService emailService) { 
            _onlineClassesDB = onlineClassesDB;
            _registrationMapper = registrationMapper;
            _courseDtoMapper = courseDtoMapper;
            _helper = helper;
            _courseMapper = courseMapper;
            _webinarMapper = webinar;
            _webinarDtoMapper = webinarDtoMapper;   
            _contactMapper = contactMapper;
            _emailService = emailService;
        }

        //Add Courses
        public void AddCourses(Course course)
        {
           //Add Courses
           var DTO = _courseDtoMapper.Map(course);
            {
                _onlineClassesDB.CoursesDto.Add(DTO);
                _onlineClassesDB.SaveChanges();
            }
        }

        //Add Webinar
        public void AddWebinar(Webinar webinar)
        {
            var Dto = _webinarDtoMapper.Map(webinar);
            {
                _onlineClassesDB.webinarDtos.Add(Dto);
                _onlineClassesDB.SaveChanges(); 
            }
        }

        //fetch Contact Details
        public List<Contact> GetContact()
        {
            var contactLists = _onlineClassesDB.ContactDto.ToList();
            return _contactMapper.Map(contactLists);
        }

        //Get Courses
        public List<Course> GetCourses()
        {
            var coursesLists = _onlineClassesDB.CoursesDto.ToList();
            return _courseMapper.Map(coursesLists);
        }

        //Get All Registrations
        public List<Registration> GetRegistrations()
        {
            var UserLists =  _onlineClassesDB.RegistrationDto.ToList();
            return _registrationMapper.Map(UserLists);
        }


        //Get List of Webinar
        public List<Webinar> GetWebinar()
        {
            var webinarLists = _onlineClassesDB.webinarDtos.ToList();
            return _webinarMapper.Map(webinarLists);
        }

        //Reply Back
        public void ReplyBack(string email, string reply)
        {
            _emailService.ReplyBack(email, reply);
        }
    }
}
