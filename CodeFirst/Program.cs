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

                var a = db.Authors
                          .Include(a => a.Books)
                          .ToList();

                foreach (Author author in a)
                {
                    Console.WriteLine(author.Name);
                    foreach (Book book in author.Books)
                    {
                        Console.WriteLine(book);
                    }
                }
            }
        }
    }
}
