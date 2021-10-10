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

namespace FormaGreen.Pages.EspacesVert
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
        public EspaceVert Espace { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Espace = await _context.Espaces_Vert.FirstOrDefaultAsync(m => m.Id == id);

            if (Espace == null)
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

            _context.Attach(Espace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspaceExists(Espace.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Details", new { id = Espace.Id });
        }

        private bool EspaceExists(int id)
        {
            return _context.Espaces_Vert.Any(e => e.Id == id);
        }
    }
}
