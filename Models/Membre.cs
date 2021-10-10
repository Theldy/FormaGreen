using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormaGreen.Models
{
    public class Membre
    {
        public int MembreId { get; set; }
        public string Nom { get; set; }
        public int TypeMembreId { get; set; }
        public string DateSouscription { get; set; }
        public string DateEcheance { get; set; }
        public string QRCode { get; set; }
        public TypeMembre TypeMembre_ { get; set; }

        
    }
}
