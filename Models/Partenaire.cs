using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormaGreen.Models
{
    public class Partenaire
    {
        public int Id { get; set; }
        [Required]
        public string Societe { get; set; }
        public string Description { get; set; }
        public string Coupon { get; set; }      
        
    }
}
