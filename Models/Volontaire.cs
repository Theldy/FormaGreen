using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormaGreen.Models
{
    public class Volontaire
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        [Url]
        public string Website { get; set; }
        [Url]
        public string Picture { get; set; }
        [Url]
        public string Map { get; set; }
    }
}
