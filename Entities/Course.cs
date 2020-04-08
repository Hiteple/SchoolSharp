using System;
using System.Collections.Generic;
using SchoolSharp.Interfaces;
using SchoolSharp.Utils;

namespace SchoolSharp.Entities
{
    public class Course: BaseSchool, IAddress
    {
        public HourType HourType { get; set;  }

        public List<Subject> Subjects { get; set; }
        
        public List<Student> Students { get; set; }
        
        // this address is class attribute
        public string Address { get; set; }
        
        // this address is from interface
        string IAddress.Address { get; set; }

        public Course(string name, HourType hour)
        {
            Name = name;
            HourType = hour;
        }

        public void ClearAddress()
        {
            Printer.DrawLine();
            Console.WriteLine($"Cleaning Course {Name}...");
        }
    }
}