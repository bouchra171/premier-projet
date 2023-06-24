namespace premier_projet.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Grade> Grades { get; set; }

        public Student()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Grades = new List<Grade>();
        }

    }
}

