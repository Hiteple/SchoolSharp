using System;
using System.Collections.Generic;
using SchoolSharp.Interfaces;
using SchoolSharp.Utils;

namespace SchoolSharp.Entities
{
    // We don't use extends in C#: we use : to implement inheritance and/or interfaces
    public class School: BaseSchool, IAddress
    {
        public int CreationYear { get; set; }
        public SchoolType SchoolType { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public string Address { get; set; }

        public List<Course> Courses { get; set; }

        public School(string name, int year, SchoolType type, string country, string city)
        {
          Name = name;
          CreationYear = year;
          SchoolType = type;
          Country = country;
          City = city;
        }

        public void ClearAddress()
        {
            Printer.DrawLine();
            Console.WriteLine($"Cleaning {Name} School...");
            foreach (var course in Courses)
            {
                // if I clean the school I'm cleaning the courses, of course
                course.ClearAddress();
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, Year: {CreationYear}, SchoolType: {SchoolType} \n Country: {Country}, City: {City}";
        }
    }
}