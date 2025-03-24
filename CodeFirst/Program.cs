using Microsoft.EntityFrameworkCore;

namespace CodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (BooksContext db = new())
            {
                //Author a1 = new Author { Name = "Alex" };
                //Author a2 = new Author { Name = "Bob" };
                //db.Authors.AddRange(a1, a2);
                //db.SaveChanges();

                //Book b1 = new Book { Name = "C++", Publishing = new DateOnly(2000, 10, 1), Pages = 100, Author = a1 };
                //Book b2 = new Book { Name = "C#", Publishing = new DateOnly(2000, 10, 1), Pages = 100, Author = a1 };
                //Book b3 = new Book { Name = "SQL", Publishing = new DateOnly(2000, 10, 1), Pages = 100, Author = a2 };
                //db.Books.AddRange(b1, b2, b3);

                //Profile p1 = new Profile { Author = a1, Login = "a1", Password = "p1" };
                //Profile p2 = new Profile { Author = a2, Login = "a2", Password = "p2" };
                //db.Profiles.AddRange(p1, p2);

                //db.SaveChanges();

                //var b = db.Books
                //          .Include(b=>b.Author)
                //          .Where(b => b.Author.Name == "Alex")
                //          .ToList();

                //foreach (Book book in b)
                //{
                //    Console.Write(book);
                //    Console.WriteLine($" {book.Author.Name}");
                //}

                //var au = db.Authors
                //          .Include(a => a.Books)
                //          .Where(a => a.Name == "Alex")
                //          .ToList();
                //foreach (Author author in au)
                //{
                //    Console.WriteLine(author.Name);
                //    foreach (Book book in author.Books)
                //    {
                //        Console.WriteLine(book);
                //    }
                //}

                //Console.WriteLine();

                //Author a = db.Authors.FirstOrDefault();
                //db.Books.Where(b => b.Author == a).Load();

                //Console.WriteLine(a.Name);
                //foreach (Book book in a.Books)
                //{
                //    Console.WriteLine(book);
                //}


                //var a = db.Authors
                //          .Include(a => a.Profile)
                //          .ToList();

                //var p = db.Profiles
                //          .Include(p => p.Author)
                //          .ToList();

                //foreach (var author in p)
                //{
                //    Console.WriteLine(author.Author.Name);
                //    Console.WriteLine(author.Login);
                //    Console.WriteLine(author.Password);
                //}


                Student s1 = new Student { Name = "Alex" };
                Student s2 = new Student { Name = "Bob" };

                db.Students.AddRange(s1, s2);

                Subject sub1 = new Subject { Name = "Math" };
                Subject sub2 = new Subject { Name = "History" };
                Subject sub3 = new Subject { Name = "Biology" };
                Subject sub4 = new Subject { Name = "C++" };


                db.Subjects.AddRange(sub1, sub2, sub3, sub4);

                Exam e1 = new Exam { Student = s1, Subject = sub1, Mark = 5 };
                Exam e2 = new Exam { Student = s1, Subject = sub2, Mark = 4 };
                Exam e3 = new Exam { Student = s2, Subject = sub1, Mark = 3 };
                Exam e4 = new Exam { Student = s2, Subject = sub2, Mark = 2 };
                Exam e5 = new Exam { Student = s2, Subject = sub3, Mark = 1 };

                db.Exams.AddRange(e1, e2, e3, e4, e5);

                db.SaveChanges();

                //var st = db.Students
                //          .Include(s => s.Exams)
                //            .ThenInclude(e => e.Subject)
                //          .ToList();

                //foreach (var student in st)
                //{
                //    Console.WriteLine(student.Name);
                //    foreach (var exam in student.Exams)
                //    {
                //        Console.WriteLine($"{exam.Subject.Name} {exam.Mark}");
                //    }
                //}


                var sub = db.Subjects
                          .Include(s => s.Students)
                            .ThenInclude(e => e.Exams)
                          .ToList();

                foreach (var subject in sub)
                {
                    Console.WriteLine(subject.Name);
                    if (subject.Exams != null)
                        foreach (var exam in subject.Exams)
                        {
                            Console.WriteLine(exam.Student.Name + " " + exam.Mark);
                        }
                }
            }
        }
    }
}
