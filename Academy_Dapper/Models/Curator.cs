using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_Dapper.Models
{
    [Table("Curators")]
    public class Curator
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
