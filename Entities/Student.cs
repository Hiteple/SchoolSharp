using System;
using System.Collections.Generic;
using System.IO.Compression;

namespace Etapa1.Entities
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