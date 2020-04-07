using System;
using System.Collections.Generic;
using Etapa1.Entities;

namespace Etapa1.Entities
{
    public class Course
    {
        public string Name { get; set; }
        public string UniqueId { get; private set; }
        public HourType HourType { get; set;  }

        public List<Subject> Subjects { get; set; }
        
        public List<Student> Students { get; set; }

        public Course(string name, HourType hour)
        {
            UniqueId = Guid.NewGuid().ToString();
            Name = name;
            HourType = hour;
        }
    }
}