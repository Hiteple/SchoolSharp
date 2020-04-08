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
            var engine = new SchoolEngine();
            engine.Initialize();
            Printer.DrawTitle("Welcome to the school!");
            
            // Print
            PrintCourses(engine.School);
            
            // Obtain Core Objects
            var objList = engine.ObtainCoreObjects();

            // using Linq to obtain list of addresses
            var iAddressList = 
                from obj in objList 
                where obj is IAddress
                select (IAddress) obj;

            engine.School.ClearAddress();

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
