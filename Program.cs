using System;
using System.Collections.Generic;
using System.Linq;
using SchoolSharp.App;
using SchoolSharp.Entities;
using SchoolSharp.Interfaces;
using SchoolSharp.Utils;
using static System.Console;

namespace SchoolSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // How to make an event listener. ProcessExit is name of event, EventAction is the callback
            // we can use lambda for the callback
            AppDomain.CurrentDomain.ProcessExit += EventAction;
            AppDomain.CurrentDomain.ProcessExit += (obj, e) => Printer.DrawTitle("Printer Line!");
            
            // Engine initialization
            var engine = new SchoolEngine();
            engine.Initialize();
            Printer.DrawTitle("Welcome to the school!");
            
            // Print
            PrintCourses(engine.School);
            
            // Obtain Core Objects with params to loop conditionally
            var objList = engine.ObtainCoreObjects(
                out int examsCounter,
                out int coursesCounter,
                out int subjectsCounter,
                out int studentsCounter
            );

            // using Linq to obtain list of addresses
            var iAddressList = 
                from obj in objList 
                where obj is IAddress
                select (IAddress) obj;

            engine.School.ClearAddress();
            
            #region Studying dictionaries
            // Dictionary
            /*
            // We can set ket and value pairs like --> <int (key), string (value)>
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            
            // Ways to update it:
            dictionary[0] = "Test 0";
            dictionary.Add(10, "Test");
            dictionary.Add(23, "Test 2");
            Printer.DrawTitle("Dictionaries");
            
            // Ways to access the contents
            
            foreach (var keyValPair in dictionary)
            {
                // Like this
                WriteLine($"Key: {keyValPair.Key}, Value: {keyValPair.Value}");
            }
            // Like this
            WriteLine(dictionary[0]);

            // We can set the key as a string
            
            var otherDic = new Dictionary<string, string>();
            otherDic["Moon"] = "What we see at the night in the sky... reflecting the sun's light";
            WriteLine($"Moon: {otherDic["Moon"]}");
            // Can we change it? No, we can replace it. Keys are UNIQUE
            otherDic["Moon"] = "Another description";
            */
            
            // Implementing the dictionary used for the school
            var dictionary = engine.GetObjectsDictionary();
            engine.PrintDictionary(dictionary, true);
            
            #endregion

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
            
            // Exams Reporter
            var reporter = new Reporter(engine.GetObjectsDictionary());
            var examsList = reporter.GetExamsList();
            
            // Capture Exam
            Exam myExam;
            string name;
            string student;
            string result;
            Printer.DrawTitle("Capturing exam by the console...");
            WriteLine("Please provide the name of the exam.");
            Printer.PressEnter();
            name = ReadLine();
            WriteLine("Please provide the student name of the exam:");
            Printer.PressEnter();
            student = ReadLine();
            WriteLine("Please provide the result of the exam:");
            Printer.PressEnter();
            result = ReadLine();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(student) || string.IsNullOrWhiteSpace(result))
            {
                throw new ArgumentException("The value provided cannot be empty");
            }

            myExam = new Exam(name, student, double.Parse(result));
            WriteLine($"{myExam.Name}, {myExam.StudentName}, {myExam.Result}");
        }

        private static void EventAction(object sender, EventArgs e)
        {
            Printer.DrawTitle("Finished program!");
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
