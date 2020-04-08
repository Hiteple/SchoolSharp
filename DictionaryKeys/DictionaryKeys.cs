namespace SchoolSharp.DictionaryKeys
{
    // Useful when creating constants to access them outside
    /*
    public struct DictionaryKeysStruct
    {
        public const string SCHOOL = "School";
        public const string COURSES = "Courses";
        public const string SUBJECTS = "Subjects";
        public const string STUDENTS = "Students";
        public const string EXAMS = "Exams";
    }
    */
    
    // But enums may be preferred and actually I'll use them in the dictionary
    public enum DictionaryKeysEnum
    {
        School, Courses, Subjects, Students, Exams
    }
}