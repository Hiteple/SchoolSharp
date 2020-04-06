using System;
using Sch.Entities;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var school = new School("Platzi", 2012);
            school.schoolType = SchoolType.Elementaryschool;
            school.country = "Colombia";
            school.city = "Bogotá";
            
            Console.WriteLine(school);
        }
    }
}
