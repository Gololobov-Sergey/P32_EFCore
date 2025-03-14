namespace CodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (BooksContext db = new())
            {
                //Book b = new Book { Name = "C++", Publishing = new DateTime(2000, 10, 1), Pages = 100 };
                //db.Books.Add(b);
                //db.SaveChanges();


                foreach (Book book in db.Books)
                {
                    Console.WriteLine(book);
                }
            }
        }
    }
}
