using System.Collections.Generic;
using Sch.Entities;

namespace Etapa1.Entities
{
    class School
    {
        public string Name { get; set; }
        public int CreationYear { get; set; }
        public SchoolType SchoolType { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        
        public List<Course> Courses { get; set; }

        public School(string name, int year)
        {
            this.Name = name;
            this.CreationYear = year;
        }
        
        public School(string name, int year, SchoolType type, string country, string city)
        {
          this.Name = name;
          this.CreationYear = year;
          this.SchoolType = type;
          this.Country = country;
          this.City = city;
        }
        
        public override string ToString()
        {
            return $"Name: {Name}, Year: {CreationYear}, SchoolType: {SchoolType} \n Country: {Country}, City: {City}";
        }
    }
}