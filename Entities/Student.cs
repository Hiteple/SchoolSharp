using System;

namespace Etapa1.Entities
{
    public class Student
    {
        public string UniqueId { get; set; }
        public string Name { get; set; }

        public Student(string name)
        {
            UniqueId = Guid.NewGuid().ToString();
            Name = name;
        }
    }
}