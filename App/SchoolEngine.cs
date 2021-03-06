using System;
using System.Collections.Generic;
using System.Linq;
using SchoolSharp.Entities;
using SchoolSharp.DictionaryKeys;
using SchoolSharp.Utils;

namespace SchoolSharp.App
{
    public sealed class SchoolEngine
    {
        // Sealed means you cannot use this for inheritance, but you can use it for instantiation
        // Abstract is the opposite: you can use for inheritance but not for instantiation (like in BaseSchool)
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
            AddExamRandomly();

            foreach (var course in School.Courses)
            {
                foreach (var student in course.Students)
                {
                    foreach (var exam in student.Exams)
                    {
                        Console.WriteLine($"{student.Name} {exam.Name}, {exam.Result}"); 
                    }
                }
            }

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
        
        #region Implementing dictionaries
        public Dictionary<DictionaryKeysEnum, IEnumerable<BaseSchool>> GetObjectsDictionary()
        {
            var dictionary = new Dictionary<DictionaryKeysEnum, IEnumerable<BaseSchool>>();
            
            // Problem: the courses key needs to recieve an IEnumerable type of BaseSchool object
            // So, we need to assign the school within an array to satisfy that condition
            // And... School.Courses is not of type BaseSchool so we need to convert it (casting)
            dictionary.Add(DictionaryKeysEnum.School, new[] {School});
            dictionary.Add(DictionaryKeysEnum.Courses, School.Courses);

            // I add the exams in a loop to avoid breaking the unique keys rule
            var temporaryListSubject = new List<Subject>();
            var temporaryListStudent = new List<Student>();
            var temporaryListExam = new List<Exam>();
            foreach (var course in School.Courses)
            {
                temporaryListSubject.AddRange(course.Subjects);
                temporaryListStudent.AddRange(course.Students);
                foreach (var student in course.Students)
                {
                    temporaryListExam.AddRange(student.Exams);
                }
            }
            dictionary.Add(DictionaryKeysEnum.Subjects, temporaryListSubject);
            dictionary.Add(DictionaryKeysEnum.Students, temporaryListStudent);
            dictionary.Add(DictionaryKeysEnum.Exams, temporaryListExam);

            return dictionary;
        }

        public void PrintDictionary(Dictionary<DictionaryKeysEnum, IEnumerable<BaseSchool>> dictionary, bool printExams)
        {
            foreach (var obj in dictionary)
            {
                Printer.DrawTitle(obj.Key.ToString());
                foreach (var val in obj.Value)
                {
                    switch (obj.Key)
                    {
                        case DictionaryKeysEnum.School:
                            Console.WriteLine("School: " + val);
                            break;
                        case DictionaryKeysEnum.Students:
                            Console.WriteLine("Students: " + val);
                            break;
                        case DictionaryKeysEnum.Courses:
                            var temporaryCourse = val as Course;
                            if (temporaryCourse != null)
                            {
                                int count = temporaryCourse.Students.Count;
                                Console.WriteLine("Course: " + val.Name + ", Students: " + count);  
                            }
                            break;
                        case DictionaryKeysEnum.Exams: 
                            if (printExams)
                            {
                                Console.WriteLine(val);
                            } 
                            break;
                        default:
                            Console.WriteLine(val);
                            break;
                    }
                }
            }
            
            if (!printExams)
            {
                Console.WriteLine("Your decided to not print exams");
            }
        }
        #endregion

        // Regions are for easier reading purposes and help in collapsing blocks of code in the IDE
        #region Here are the methods that add custom-typed objects to the school
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

        private void AddExamRandomly()
        {
            Random random = new Random();
            foreach (var course in School.Courses)
            {
                foreach (var student in course.Students)
                {
                    List<Exam> examsList = new List<Exam>()
                    {
                        new Exam("Mathematics Exam", $"{student.Name}", Math.Round(random.NextDouble() * (5.0 - 0.1) + 0.1, 2)),
                        new Exam("English Exam", $"{student.Name}", Math.Round(random.NextDouble() * (5.0 - 0.1) + 0.1, 2)),
                        new Exam("Cience Exam", $"{student.Name}", Math.Round(random.NextDouble() * (5.0 - 0.1) + 0.1, 2)),
                        new Exam("Philosophy Exam", $"{student.Name}", Math.Round(random.NextDouble() * (5.0 - 0.1) + 0.1, 2)),
                    };
                    student.Exams = examsList;
                }
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
        #endregion
        
        private static bool PredicateMethod(Course courseObj)
        {
            return courseObj.Name == "600";
        }
        
        #region Method to obtain core objects: first with params to loop conditionally
        public IReadOnlyList<BaseSchool> ObtainCoreObjects(
            out int examsCounter,
            out int coursesCounter,
            out int subjectsCounter,
            out int studentsCounter,
            bool obtainExams = true,
            bool obtainStudents = true, 
            bool obtainSubjects = true, 
            bool obtainCourses = true)
        {
            // All of them initialized in 0 in stylish way
            examsCounter = coursesCounter = subjectsCounter = studentsCounter = 0;
            var objList = new List<BaseSchool>();
            objList.Add(School);
            
            if (obtainCourses)
            {
                objList.AddRange(School.Courses); 
            }

            coursesCounter = School.Courses.Count;
            foreach (var course in School.Courses)
            {
                subjectsCounter += course.Subjects.Count;
                if (obtainSubjects)
                {
                    objList.AddRange(course.Subjects);
                }

                studentsCounter += course.Students.Count;
                if (obtainStudents)
                {
                    objList.AddRange(course.Students);
                }
                if (obtainExams)
                {
                    foreach (var student in course.Students)
                    {
                        objList.AddRange(student.Exams);
                        examsCounter += student.Exams.Count;
                    } 
                }
            }
            
            return objList.AsReadOnly();
        }
        #endregion
    }
}