using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormaGreen.Models
{
    public class EspaceVert
    {
        public int Id { get; set; }
        [Required]
        public string Etablissement { get; set; }
        public string Ville { get; set; }
        public int CP { get; set; }
        public string Adresse { get; set; }
        public string Representant { get; set; }
        public string Contact { get; set; }
        [Url]
        public string Map { get; set; }
    }
}
