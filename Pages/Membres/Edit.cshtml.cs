using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FormaGreen.Data;
using FormaGreen.Models;

namespace FormaGreen.Pages.Membres
{
    [Authorize(Roles = "staff,admin")]
    public class EditModel : PageModel
    {
        private readonly FormaGreen.Data.FormaGreenContext _context;

        public EditModel(FormaGreen.Data.FormaGreenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Membre Membre { get; set; }
        public List<TypeMembre> Categories { get; set; }
        [BindProperty]
        public int TypeMembreId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Membre = await _context.Membres.FirstOrDefaultAsync(m => m.MembreId == id);
            Categories = _context.Types_Membre.ToList();
            TypeMembreId = Membre.TypeMembre_.TypeMembreId;

            if (Membre == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Categories = _context.Types_Membre.ToList();
            Membre.TypeMembre_ = Categories.Where(r => r.TypeMembreId == TypeMembreId).FirstOrDefault();
            _context.Attach(Membre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembreExists(Membre.MembreId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Details", new { id = Membre.MembreId });
        }

        private bool MembreExists(int id)
        {
            return _context.Membres.Any(e => e.MembreId == id);
        }
    }
}
