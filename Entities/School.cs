namespace Sch.Entities
{
    class School
    {
        public string name { get; set; }
        public int creationYear { get; set; }
        public string country { get; set; }

        public School(string name, int year)
        {
            this.name = name;
            this.creationYear = year;
        }
    }
}