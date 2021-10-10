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

namespace FormaGreen.Pages.EspacesVert
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Espace = await _context.Espaces_Vert.FindAsync(id);

            if (Espace != null)
            {
                _context.Espaces_Vert.Remove(Espace);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
