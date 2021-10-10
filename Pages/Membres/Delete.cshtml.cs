using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FormaGreen.Data;
using FormaGreen.Models;

namespace FormaGreen.Pages.Membres
{
    [Authorize(Roles = "staff,admin")]
    public class DeleteModel : PageModel
    {
        private readonly FormaGreen.Data.FormaGreenContext _context;

        public DeleteModel(FormaGreen.Data.FormaGreenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Membre Membre { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Membre = await _context.Membres.Include(m => m.TypeMembre_).FirstOrDefaultAsync(m => m.MembreId == id);

            if (Membre == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Membre = await _context.Membres.FindAsync(id);

            if (Membre != null)
            {
                _context.Membres.Remove(Membre);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
