using System;
using Sch.Entities;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var school = new School("Platzi", 2012, SchoolType.Elementaryschool, "Colombia", "Bogotá");
            var course1 = new Course();
            course1.name = "301";

            var course2 = new Course();
            course2.name = "302";

            var course3 = new Course();
            course3.name = "303";

            Console.WriteLine(school);
            Console.WriteLine("===========");
            Console.WriteLine(course1.name + ", " + course1.uniqueId);
            Console.WriteLine("===========");
            Console.WriteLine(course2.name + ", " + course2.uniqueId);
            Console.WriteLine("===========");
            Console.WriteLine(course3.name + ", " + course3.uniqueId);
        }
    }
}
