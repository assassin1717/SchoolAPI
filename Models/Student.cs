using System.Collections.Generic;

namespace SchoolAPI.Models
{
    public class Subject
    {
        public string Name { get; set; }
        public double Avg { get; set; }
    }

    public class Student
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsMale { get; set; }
        public List<Subject> Subjects { get; set; }
        public double? Avg { get; set; }
    }
}
