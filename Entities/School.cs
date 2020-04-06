namespace Sch.Entities
{
    class School
    {
        public string name { get; set; }
        public int creationYear { get; set; }
        public SchoolType schoolType { get; set; }
        public string country { get; set; }
        public string city { get; set; }

        public School(string name, int year)
        {
            this.name = name;
            this.creationYear = year;
        }
        
        public override string ToString()
        {
            return $"Name: {name}, SchoolType: {schoolType} \n Country: {country}, City: {city}";
        }
    }
}