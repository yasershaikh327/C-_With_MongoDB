﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Access.Mappers.UIMapper.Model
{
    public class CourseBook
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }
        public string Instructor { get; set; }
    }
}