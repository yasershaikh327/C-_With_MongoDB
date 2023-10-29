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
    public class CourseDtoMapper : ICourseDtoMapper
    {
        public CourseDto Map(Course course)
        {
            var courseDto = new CourseDto();
            courseDto.Id = course.Id;
            courseDto.CourseName = course.CourseName;
            courseDto.CourseVideos = course.CourseVideos;
            courseDto.Price = course.Price;
            courseDto.Descsription = course.Descsription;
            courseDto.Instructor = course.Instructor;
            return courseDto;

        }

        public class CourseDtos
        {
            public CourseDto Course { get; set; }
            public CourseDtos()
            {
                Course = new CourseDto();   
            }
        }
    }
}
