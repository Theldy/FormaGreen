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

namespace FormaGreen.Pages.Partenaires
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
        public Partenaire Partenaire { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Partenaire = await _context.Partenaires.FirstOrDefaultAsync(m => m.Id == id);

            if (Partenaire == null)
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

            Partenaire = await _context.Partenaires.FindAsync(id);

            if (Partenaire != null)
            {
                _context.Partenaires.Remove(Partenaire);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
