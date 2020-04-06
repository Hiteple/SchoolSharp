using System;
using Sch.Entities;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var school = new School("Plazti", 2012);
            Console.WriteLine(school.name);
        }
    }
}
