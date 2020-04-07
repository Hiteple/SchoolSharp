using System;
using Sch.Entities;

namespace Etapa1.Entities
{
    public class Course
    {
        public string Name { get; set; }
        public string UniqueId { get; private set; }
        public HourType HourType { get; set;  }

        public Course()
        {
            this.UniqueId = Guid.NewGuid().ToString();
        }
    }
}