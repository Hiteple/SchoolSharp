namespace SchoolSharp.Entities
{
    public class Exam: BaseSchool
    {
        public string StudentName { get; set; }
        
        public Subject Subject { get; set; }
        
        public double Result { get; set; }

        public Exam(string name, string studentName, double result)
        {
            Name = name;
            StudentName = studentName;
            Result = result;
        }

        public override string ToString()
        {
            return $"{Result}, {StudentName}";
        }
    }
}