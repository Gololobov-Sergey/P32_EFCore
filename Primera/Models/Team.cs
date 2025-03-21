using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primera.Models
{
    public class Team
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? City { get; set; }

        public List<Player> Players { get; set; }

        public List<Match> Matches1 { get; set; }
        public List<Match> Matches2 { get; set; }

    }
}
