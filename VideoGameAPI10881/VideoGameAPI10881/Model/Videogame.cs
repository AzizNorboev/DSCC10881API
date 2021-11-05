using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameAPI10881.Model
{
    public class Videogame
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Publisher { get; set; }

    }
}
