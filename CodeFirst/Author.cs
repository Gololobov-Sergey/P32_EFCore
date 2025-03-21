using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    //[NotMapped]
    [Table("Autors")]
    public class Author
    {
        //int id;

        public int Id { get; set; }

        public string? Name { get; set; }

        [NotMapped]
        public string? Address { get; set; }


        public List<Book> Books { get; set; }

        //public Author(int id, string name)
        //{
        //    this.id = id;
        //    this.Name = name;
        //}
    }
}
