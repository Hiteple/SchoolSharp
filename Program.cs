using System;
using Etapa1.App;
using Etapa1.Entities;
using Etapa1.Utils;
using static System.Console;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new SchoolEngine();
            engine.Initialize();
            Printer.DrawTitle("Welcome to the school!");
            
            // Print
            PrintCourses(engine.School);
            
            // Obtain Core Objects
            var objList = engine.ObtainCoreObjects();
            WriteLine("wdwd");

            /*
            // Polymorphism tests
            Printer.DrawLine();
            Printer.DrawLine();
            Printer.DrawLine();
            Printer.DrawTitle("Polymorphism tests:");
            
            var studentTest = new Student("Pablito");
            BaseSchool ob = studentTest;
            
            WriteLine("Student: Polymorphism works?");
            WriteLine($"{studentTest.GetType()}");
            WriteLine($"{ob.GetType()}");
            */
        }
        private static void PrintCourses(School school)
        {
            Printer.DrawTitle("School Courses:");

            if (school?.Courses != null)
            {
                foreach (var course in school.Courses)
                {
                    WriteLine($"Name: {course.Name}, Id: {course.UniqueId}, Hour: {course.HourType}");
                }
            }
        }
    }
}
