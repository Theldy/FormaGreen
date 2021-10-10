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

namespace FormaGreen.Pages.Partenaires
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Partenaire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartenaireExists(Partenaire.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Details", new { id = Partenaire.Id });
        }

        private bool PartenaireExists(int id)
        {
            return _context.Partenaires.Any(e => e.Id == id);
        }
    }
}
