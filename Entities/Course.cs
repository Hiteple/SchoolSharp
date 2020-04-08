using System;
using System.Collections.Generic;
using Etapa1.Entities;

namespace Etapa1.Entities
{
    public class Course: BaseSchool
    {
        public HourType HourType { get; set;  }

        public List<Subject> Subjects { get; set; }
        
        public List<Student> Students { get; set; }

        public Course(string name, HourType hour)
        {
            Name = name;
            HourType = hour;
        }
    }
}