using System.Collections.Generic;

namespace SchoolSharp.Entities
{
    public class Student: BaseSchool
    {
        public List<Exam> Exams { get; set; }

        public Student(string name)
        {
            Name = name;
        }
    }
}