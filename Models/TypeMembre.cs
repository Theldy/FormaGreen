using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormaGreen.Models
{
    public class TypeMembre
    {
        public int TypeMembreId { get; set; }
        [Required]
        public string Label { get; set; }
    }
}
