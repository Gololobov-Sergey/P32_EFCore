using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Exam> Exams { get; set; }

        public List<Subject> Subjects { get; set; }
    }

    public class Subject
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Exam> Exams { get; set; }

        public List<Student> Students { get; set; }
    }

    public class Exam
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int Mark { get; set; }
    }
}
