using System;
using System.Collections.Generic;
using Etapa1.App;
using Etapa1.Entities;
using static System.Console;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new SchoolEngine();
            engine.Initialize();
            // Print
            PrintCourses(engine.School);
        }
        private static void PrintCourses(School school)
        {
            WriteLine("===============");
            WriteLine("School's courses:");
            WriteLine("===============");

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
