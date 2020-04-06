using System;

namespace Sch.Entities
{
    public class Course
    {
        public string name { get; set; }
        public string uniqueId { get; private set; }
        public HourType hourType { get; set;  }

        public Course()
        {
            this.uniqueId = Guid.NewGuid().ToString();
        }
    }
}