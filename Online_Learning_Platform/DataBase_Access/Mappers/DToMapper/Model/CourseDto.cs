using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Access.Mappers.DToMapper.Model
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string CourseVideos { get; set; }
        public string CourseName { get; set; }
        public int Price { get; set; }
        public string Instructor { get; set; }
        public string Descsription { get; set; }
    }
}
