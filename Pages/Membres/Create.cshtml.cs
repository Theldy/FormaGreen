using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FormaGreen.Data;
using FormaGreen.Models;

namespace FormaGreen.Pages.Membres
{
    [Authorize(Roles = "staff,admin")]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Models.Membre Membre{ get; set; }
        [BindProperty]
        public List<TypeMembre> Categories { get; set;  }
        [BindProperty]
        public int TypeMembreId { get; set; }
        private readonly FormaGreen.Data.FormaGreenContext _context;

        public CreateModel(FormaGreen.Data.FormaGreenContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Categories = _context.Types_Membre.ToList();
            return Page();
        }
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            Categories = _context.Types_Membre.ToList();
            Membre.TypeMembre_ = Categories.Where(r => r.TypeMembreId == TypeMembreId).FirstOrDefault();
            if (!ModelState.IsValid || Membre.TypeMembre_==null)
            {
                return Page();
            }

            _context.Membres.Add(Membre);
            _context.SaveChanges();

            return RedirectToPage("./Details", new { id = Membre.MembreId });
        }
    }
}
