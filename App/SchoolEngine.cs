using System;
using System.Collections.Generic;
using System.Linq;
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
            // Courses
            AddCourses();

            // Students generated inside AddCourses

            // Subjects
            AddSubjects();

            // Exams
            AddExams();

            // ADD //
            // Add
            //School.Courses.Add(new Course("102", HourType.Afternoon));
            //School.Courses.Add(new Course("202", HourType.Afternoon));

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

        private void AddExams()
        {
            //throw new NotImplementedException();
        }

        private void AddSubjects()
        {
            foreach (var course in School.Courses)
            {
                List<Subject> subjectsList = new List<Subject>()
                {
                    new Subject("Mathematics"),
                    new Subject("English"),
                    new Subject("Cience"),
                    new Subject("Philosophy")
                };
                course.Subjects = subjectsList;
            }
        }
        
        private IEnumerable<Student> AddStudentsRandomly(int studentsQuantity)
        {
            string[] name1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] name2 = {"Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes"};
            string[] lastname1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };

            // Using Linq, similar to SQL (other way is to nest 3 foreach to mix all.... not gonna happen)
            var studentsList = 
                from n1 in name1
                from n2 in name2
                from l1 in lastname1
                select new Student($"{n1} {n2} {l1}");

            // Using lambda to order
            return studentsList.OrderBy(student => student.UniqueId).Take(studentsQuantity).ToList();
        }

        private void AddCourses()
        {
            School.Courses = new List<Course>()
            {
                new Course("101", HourType.Morning),
                new Course("201", HourType.Morning),
                new Course("301", HourType.Morning),
                new Course("401", HourType.Morning),
                new Course("501", HourType.Morning)
            };

            // Generate random limit between 5 and 20
            Random randomQty = new Random();
            foreach (var course in School.Courses)
            {
                int randomNum = randomQty.Next(5, 20);
                course.Students = AddStudentsRandomly(randomNum).ToList();
            }
        }
        
        private static bool PredicateMethod(Course courseObj)
        {
            return courseObj.Name == "600";
        }
    }
}