using System;

namespace Etapa1.Entities
{
    public class Exam
    {
        public string UniqueId { get; set; }
        public string Name { get; set; }
        
        public string StudentName { get; set; }
        
        public Subject Subject { get; set; }
        
        public double Result { get; set; }

        public Exam(string name, string studentName, double result)
        {
            UniqueId = Guid.NewGuid().ToString();
            Name = name;
            StudentName = studentName;
            Result = result;
        }
    }
}