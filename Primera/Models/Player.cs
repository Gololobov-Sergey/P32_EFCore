using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primera.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public List<Goal> Goals { get; set; }
    }
}
