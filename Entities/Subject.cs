using System;

namespace Etapa1.Entities
{
    public class Subject
    {
        public string UniqueId { get; set; }
        public string Name { get; set; }

        public Subject(string name)
        {
            UniqueId = Guid.NewGuid().ToString();
            Name = name;
        }
    }
}