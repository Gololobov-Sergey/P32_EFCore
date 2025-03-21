using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst
{
    public class Book
    {
        //[Column("book_id")]
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        public DateOnly Publishing { get; set; }

        public int Pages { get; set; }


        //public int AuhtorId { get; set; }
        public Author Author { get; set; }


        public override string ToString()
        {
            return $"{Id} {Name} {Publishing.ToShortDateString()} {Pages}";
        }
    }
}
