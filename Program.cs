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

            school.Courses = new Course[]
            {
                new Course() {Name = "101"},
                new Course() {Name = "102"},
                new Course() {Name = "103"}
            };

            PrintCourses(school);
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
                    WriteLine($"Name: {course.Name}, Id: {course.UniqueId}");
                }
            }
        }
    }
}
