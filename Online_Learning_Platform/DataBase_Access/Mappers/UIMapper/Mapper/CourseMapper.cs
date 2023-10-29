using DataBase_Access.Mappers.DToMapper.Model;
using DataBase_Access.Mappers.UIMapper.IMapper;
using DataBase_Access.Mappers.UIMapper.Model;
using Microsoft.AspNetCore.Http;
using Online_Learning_Platform.Mappers.UIMapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Online_Learning_Platform.Mappers.UIMapper.Mapper.RegistrationDtoMapper;

namespace DataBase_Access.Mappers.UIMapper.Mapper
{
    public class CourseMapper : ICourseMapper
    {
        public Course Map(CourseDto courseDto)
        {
            var course = new Course();
            course.Id = courseDto.Id;
            course.CourseName = courseDto.CourseName;
            course.CourseVideos = courseDto.CourseVideos;
            course.Price = courseDto.Price;
            course.Descsription = courseDto.Descsription;
            course.Instructor = courseDto.Instructor;
            return course;
        }

        public List<Course> Map(List<CourseDto> courseDto)
        {
            var Dtos = new List<Course>();
            foreach (var dto in courseDto)
            {
                var courseItem = new Course
                {
                    Id = dto.Id,
                    Price = dto.Price,
                    CourseName = dto.CourseName,
                    CourseVideos = dto.CourseVideos,
                    Descsription = dto.Descsription,
                    Instructor = dto.Instructor
            
                };

                Dtos.Add(courseItem);
            }
            return Dtos;
        }
    }
}
