﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primera.Models
{
    public class Position
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        public List<Player> Players { get; set; }
    }
}
