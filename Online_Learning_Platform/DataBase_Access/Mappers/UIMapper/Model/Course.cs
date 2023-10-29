using Microsoft.AspNetCore.Http;


namespace DataBase_Access.Mappers.UIMapper.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseVideos { get; set; }
        public string CourseName { get; set; }
        public int Price { get; set; }
        public string Instructor { get; set; }
        public string Descsription { get; set; }
    }
}
