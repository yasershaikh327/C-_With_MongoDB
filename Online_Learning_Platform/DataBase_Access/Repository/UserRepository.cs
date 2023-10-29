using DataBase_Access.DataBase_Management;
using DataBase_Access.Helper;
using DataBase_Access.IRepository;
using DataBase_Access.Mappers.DToMapper.IMapper;
using DataBase_Access.Mappers.UIMapper.IMapper;
using DataBase_Access.Mappers.UIMapper.Model;
using FoodManagement_UI.Services;
using Microsoft.EntityFrameworkCore;
using Online_Learning_Platform.Mappers.UIMapper.Model;

namespace DataBase_Access.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IRegistrationDtoMapper _registrationDtoMapper;
        private readonly ICourseBookMapper _courseBookMapper;
        private readonly IContactDtoMapper _contactDtoMapper;
        private readonly ICourseBookDtoMapper _courseBookDtoMapper;
        private readonly IHelper _helper;
        private readonly IEmailService _emailService;
        private readonly OnlineClassesDB _onlineClassesDB;
        public UserRepository(IRegistrationDtoMapper registrationMapper,OnlineClassesDB onlineClassesDB,IHelper helper,IContactDtoMapper contactDtoMapper,IEmailService emailService,ICourseBookDtoMapper courseBookDtoMapper,ICourseBookMapper courseBookMapper) { 
            _registrationDtoMapper = registrationMapper;
            _onlineClassesDB = onlineClassesDB;
            _helper = helper;
            _contactDtoMapper = contactDtoMapper;
            _emailService = emailService;
            _courseBookDtoMapper = courseBookDtoMapper;
            _courseBookMapper = courseBookMapper;
        }


        //Add Users
        public void AddUsers(Registration registration)
        {
            var RegistrationDto = _registrationDtoMapper.Map(registration);
            {
                RegistrationDto.Password = _helper.Base64Encode(registration.Password);
                _onlineClassesDB.RegistrationDto.Add(RegistrationDto);
                _onlineClassesDB.SaveChanges();
            }
        }

        //Book Course
        public bool BookCourse(CourseBook book)
        {
            var Dto = _courseBookDtoMapper.Map(book);
            {
                _onlineClassesDB.courseBookDtos.Add(Dto);
                _onlineClassesDB.SaveChanges();
                return true;
            }
        }


        //Check if Course is Booked
        public bool CheckIfCourseisBooked(CourseBook book)
        {
            var result = _onlineClassesDB.courseBookDtos.FirstOrDefault(x => x.Email == book.Email && x.Course == book.Course);
            if (result == null)
                return true;
            return false;
        }

        //Check Email if Exists
        public bool CheckIfUSerExists(string Email)
        {
           var result =  _onlineClassesDB.RegistrationDto.FirstOrDefault(x => x.Email == Email); 
            if (result == null) 
                return false;
            return true;
        }


        //Contact Us
        public void ContactUs(Contact contact)
        {
            var contactDtoss = _contactDtoMapper.Map(contact);
            {
                _onlineClassesDB.ContactDto.Add(contactDtoss);
                _onlineClassesDB.SaveChanges();
                _emailService.Contact(contactDtoss.Email);
            }
          
        }

        //Get List pf Bookings
        public List<CourseBook> GetBookingDetails()
        {
            var bookingLists = _onlineClassesDB.courseBookDtos.ToList();
            return _courseBookMapper.Map(bookingLists);
        }

        //Login
        public int LoginProcess(Login login)
        {
            var user = _onlineClassesDB.RegistrationDto.FirstOrDefault(u =>
            u.Email == login.Email &&
            u.Password == _helper.Base64Encode(login.Password).ToString());
            if (user != null)
                return user.Id;
            return -1;
        }

        //Check for Old Password
        public bool OldPassword(UpdatePassword updatepassword)
        {
            var user = _onlineClassesDB.RegistrationDto.FirstOrDefault(b =>
              b.Id == updatepassword.Id &&
              b.Password == _helper.Base64Encode(updatepassword.oldPassword));
            bool isCorrectPassword = user != null;
            return isCorrectPassword;
        }

        //Update Password
        public bool Updatepassword(UpdatePassword updatepassword)
        {
            var registration = _onlineClassesDB.RegistrationDto.FirstOrDefault(b => b.Id == updatepassword.Id);
            if (registration != null)
                registration.Password = _helper.Base64Encode(updatepassword.Password);
            _onlineClassesDB.SaveChanges();
            return true;
        }

        //Fetch Individual Details
        public List<CourseBook> GetUserDetails(string Email)
        {
            var bookingLists = _onlineClassesDB.courseBookDtos.Where(D => D.Email == Email).ToList();
            return _courseBookMapper.Map(bookingLists);
        }

        //Recover Forget Password
        public void RecoverViaEmail(string Email)
        {
            string recoverPassword = _helper.GenerateRandomPassword();
            var registration = _onlineClassesDB.RegistrationDto.FirstOrDefault(b => b.Email == Email);
            if (registration != null)
                registration.Password = _helper.Base64Encode(recoverPassword);
            _onlineClassesDB.SaveChanges();
            _emailService.Recover(Email, recoverPassword);
        }
    }
}
