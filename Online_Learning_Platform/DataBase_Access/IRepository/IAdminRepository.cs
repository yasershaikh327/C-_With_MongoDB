using DataBase_Access.Mappers.UIMapper.Model;
using Microsoft.AspNetCore.Http;
using Online_Learning_Platform.Mappers.UIMapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Access.IRepository
{
    public interface IAdminRepository
    {
        public List<Registration> GetRegistrations();
        public List<Course> GetCourses();
        public List<Webinar> GetWebinar();
        public List<Contact> GetContact();
        public void AddCourses(Course course);
        public void AddWebinar(Webinar webinar);
        public void ReplyBack(string email, string reply);
    }
}
