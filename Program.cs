using System;
using Etapa1.Entities;
using Sch.Entities;
using static System.Console;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var school = new School("Platzi", 2012, SchoolType.Elementaryschool, "Colombia", "Bogotá");
            var course1 = new Course();
            course1.Name = "301";

            var course2 = new Course();
            course2.Name = "302";

            var course3 = new Course();
            course3.Name = "303";
            
            

            WriteLine(school);
            Console.WriteLine("===========");
            Console.WriteLine(course1.Name + ", " + course1.UniqueId);
            Console.WriteLine("===========");
            Console.WriteLine(course2.Name + ", " + course2.UniqueId);
            Console.WriteLine("===========");
            Console.WriteLine(course3.Name + ", " + course3.UniqueId);
        }
    }
}
