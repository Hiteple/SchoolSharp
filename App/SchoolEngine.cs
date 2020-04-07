using System;
using System.Collections.Generic;
using Etapa1.Entities;

namespace Etapa1.App
{
    public class SchoolEngine
    {
        public School School { get; set; }

        public SchoolEngine()
        {
            School = new School("Platzi", 2012, SchoolType.Elementaryschool, "Colombia", "Bogotá");
        }

        public void Initialize()
        {
            School.Courses = new List<Course>()
            {
                new Course("101", HourType.Morning),
                new Course("201", HourType.Morning),
                new Course("301", HourType.Morning)
            };

            // ADD //
            // Add
            School.Courses.Add(new Course("102", HourType.Afternoon));
            School.Courses.Add(new Course("202", HourType.Afternoon));
            
            /*
            // REMOVE //
            // Remove all
            School.Courses.Clear();
            
            // Remove one by item
            Course temporaryCourse = new Course("500", HourType.Afternoon);
            School.Courses.Add(temporaryCourse);
            School.Courses.Remove(temporaryCourse);
            
            // Remove by property (needs to call a method and check)
            // I use a delegate for this with Predicate<T> and assign a method
            // This Predicate<T> Object needs to recieve a certain Type and return a boolean
            Course temporaryCourse2 = new Course("600", HourType.Afternoon);
            School.Courses.Add(temporaryCourse2);
            Predicate<Course> myPredicate = PredicateMethod;
            School.Courses.RemoveAll(myPredicate);
            
            // Another way using delegate keyword
            Course temporaryCourse3 = new Course("600", HourType.Afternoon);
            School.Courses.Add(temporaryCourse3);
            School.Courses.RemoveAll(delegate(Course course)
            {
                return course.Name == "600";
            });
            
            // Another way using lambda expression
            Course temporaryCourse4 = new Course("600", HourType.Afternoon);
            School.Courses.Add(temporaryCourse4);
            School.Courses.RemoveAll(course => course.Name == "600" && course.HourType == HourType.Morning);
            */
        }
        
        private static bool PredicateMethod(Course courseObj)
        {
            return courseObj.Name == "600";
        }
    }
}