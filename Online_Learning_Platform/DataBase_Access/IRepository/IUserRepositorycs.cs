using DataBase_Access.Mappers.UIMapper.Model;
using Online_Learning_Platform.Mappers.UIMapper.Model;


namespace DataBase_Access.IRepository
{
    public interface IUserRepository
    {
        public void AddUsers(Registration registration);
        public bool CheckIfUSerExists(string Email);
        public int LoginProcess(Login login);
        public void ContactUs(Contact contact);
        public bool CheckIfCourseisBooked(CourseBook book);
        public bool BookCourse(CourseBook book);
        public List<CourseBook> GetBookingDetails();
        public bool OldPassword(UpdatePassword updatepassword);
        public bool Updatepassword(UpdatePassword updatepassword);
        public List<CourseBook> GetUserDetails(string Email);
        public void RecoverViaEmail(string Email);
    }
}
