using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Book
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public DateTime Publishing { get; set; }

        public int Pages { get; set; }

        //public string Author { get; set; }


        public override string ToString()
        {
            return $"{Id} {Name} {Publishing.ToShortDateString()} {Pages}";
        }
    }
}
