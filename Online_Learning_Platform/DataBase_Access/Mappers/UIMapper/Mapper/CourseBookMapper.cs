using DataBase_Access.Mappers.DToMapper.Model;
using DataBase_Access.Mappers.UIMapper.IMapper;
using DataBase_Access.Mappers.UIMapper.Model;
using Online_Learning_Platform.Mappers.UIMapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Access.Mappers.UIMapper.Mapper
{
    public class CourseBookMapper : ICourseBookMapper
    {
        public CourseBook Map(CourseBookDto courseBookDto)
        {
            var book = new CourseBook();
            book.Id = courseBookDto.Id;
            book.Course = courseBookDto.Course;
            book.User = courseBookDto.User;
            book.Email = courseBookDto.Email;
            book.Instructor = courseBookDto.Instructor; 
            return book;
        }

        public List<CourseBook> Map(List<CourseBookDto> courseBookDto)
        {
            var courseBookDtos = new List<CourseBook>();
            foreach (var dto in courseBookDto)
            {
                var courseBookItem = new CourseBook
                {
                    Id = dto.Id,
                    User = dto.User,
                    Course = dto.Course,
                    Email = dto.Email,
                    Instructor = dto.Instructor
                };

                courseBookDtos.Add(courseBookItem);
            }
            return courseBookDtos;
        }
    }
}
