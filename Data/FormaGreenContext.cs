using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FormaGreen.Models;

namespace FormaGreen.Data
{
    public class FormaGreenContext : DbContext
    {
        public FormaGreenContext (DbContextOptions<FormaGreenContext> options)
            : base(options)
        {
        }

        public DbSet<FormaGreen.Models.Membre> Membres { get; set; }
        public DbSet<FormaGreen.Models.TypeMembre> Types_Membre { get; set; }
        public DbSet<FormaGreen.Models.Partenaire> Partenaires { get; set; }
        public DbSet<FormaGreen.Models.EspaceVert> Espaces_Vert { get; set; }
    }
}
