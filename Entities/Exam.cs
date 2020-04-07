using System;

namespace Etapa1.Entities
{
    public class Exam
    {
        public string UniqueId { get; set; }
        public string Name { get; set; }
        
        public Student Student { get; set; }
        
        public Subject Subject { get; set; }
        
        public float Result { get; set; }

        public Exam(string name)
        {
            UniqueId = Guid.NewGuid().ToString();
            Name = name;
        }
    }
}