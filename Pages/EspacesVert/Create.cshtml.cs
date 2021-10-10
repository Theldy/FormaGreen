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

namespace FormaGreen.Pages.EspacesVert
{
    [Authorize(Roles = "staff,admin")]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public EspaceVert Espace{ get; set; }

        private readonly FormaGreen.Data.FormaGreenContext _context;

        public CreateModel(FormaGreen.Data.FormaGreenContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Espaces_Vert.Add(Espace);
            _context.SaveChanges();

            return RedirectToPage("./Details", new { id = Espace.Id });
        }
    }
}
