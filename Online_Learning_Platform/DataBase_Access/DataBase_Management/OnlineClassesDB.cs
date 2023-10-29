using DataBase_Access.Mappers.DToMapper.Model;
using DataBase_Access.Mappers.UIMapper.Model;
using Microsoft.EntityFrameworkCore;
using Online_Learning_Platform.Mappers.UIMapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Access.DataBase_Management
{

        public class OnlineClassesDB : DbContext
        {
            public OnlineClassesDB(DbContextOptions<OnlineClassesDB> options) : base(options)
            {
            }


            public DbSet<RegistrationDto> RegistrationDto { get; set; }
            public DbSet<ContactDto> ContactDto { get; set; }
            public DbSet<CourseDto> CoursesDto { get; set; }
            public DbSet<CourseBookDto> courseBookDtos { get; set; }
            public DbSet<WebinarDto> webinarDtos { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<RegistrationDto>().ToTable("Registration");
                modelBuilder.Entity<ContactDto>().ToTable("Contact");
                modelBuilder.Entity<CourseDto>().ToTable("Courses");
                modelBuilder.Entity<CourseBookDto>().ToTable("BookCourses");
                modelBuilder.Entity<WebinarDto>().ToTable("Webinar");
            }
        }
    }

