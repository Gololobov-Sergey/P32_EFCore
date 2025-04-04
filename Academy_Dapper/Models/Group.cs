using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_Dapper.Models
{
    [Table("Groups")]
    public class Group
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }

        public int CuratorId { get; set; }

        public Curator? Curator { get; set; }
    }
}
