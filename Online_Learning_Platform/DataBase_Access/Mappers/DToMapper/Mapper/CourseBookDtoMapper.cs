using DataBase_Access.Mappers.DToMapper.IMapper;
using DataBase_Access.Mappers.DToMapper.Model;
using DataBase_Access.Mappers.UIMapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Access.Mappers.DToMapper.Mapper
{
    public class CourseBookDtoMapper : ICourseBookDtoMapper
    {
        public CourseBookDto Map(CourseBook course)
        {
            var Dto = new CourseBookDto();
            Dto.Id = course.Id;
            Dto.Course = course.Course;
            Dto.Email = course.Email;
            Dto.User = course.User;
            Dto.Instructor = course.Instructor; 
            return Dto;
        }
    }
}
