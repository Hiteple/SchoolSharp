using System;
using System.Collections.Generic;
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

            school.Courses = new List<Course>()
            {
                new Course("101", HourType.Morning),
                new Course("201", HourType.Morning),
                new Course("301", HourType.Morning)
            };

            // Add
            school.Courses.Add(new Course("102", HourType.Afternoon));
            school.Courses.Add(new Course("202", HourType.Afternoon));
            
            // Remove all
            school.Courses.Clear();
            
            // Remove one by item
            Course temporaryCourse = new Course("500", HourType.Afternoon);
            school.Courses.Add(temporaryCourse);
            school.Courses.Remove(temporaryCourse);
            
            // Remove by property (needs to call a method and check)
            // I use a delegate for this with Predicate<T> and assign a method
            // This Predicate<T> Object needs to recieve a certain Type and return a boolean
            Course temporaryCourse2 = new Course("600", HourType.Afternoon);
            school.Courses.Add(temporaryCourse2);
            Predicate<Course> myPredicate = PredicateMethod;
            school.Courses.RemoveAll(myPredicate);
            
            // Print
            PrintCourses(school);
        }

        private static bool PredicateMethod(Course courseObj)
        {
            return courseObj.Name == "600";
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
