using System;
using Sch.Entities;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var school = new School("Platzi", 2012, SchoolType.Elementaryschool, "Colombia", "Bogotá");
            Console.WriteLine(school);
        }
    }
}
