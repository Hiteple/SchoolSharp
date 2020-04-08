using System.Collections.Generic;

namespace Etapa1.Entities
{
    public class School: BaseSchool
    {
        public int CreationYear { get; set; }
        public SchoolType SchoolType { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        
        public List<Course> Courses { get; set; }

        public School(string name, int year, SchoolType type, string country, string city)
        {
          Name = name;
          CreationYear = year;
          SchoolType = type;
          Country = country;
          City = city;
        }
        
        public override string ToString()
        {
            return $"Name: {Name}, Year: {CreationYear}, SchoolType: {SchoolType} \n Country: {Country}, City: {City}";
        }
    }
}