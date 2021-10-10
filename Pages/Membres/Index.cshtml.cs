using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FormaGreen.Data;
using FormaGreen.Models;

namespace FormaGreen.Pages.Membres
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly FormaGreen.Data.FormaGreenContext _context;
        public List<Models.Membre> Membres { get; set; }
        public int TotalMembres { get; set; }
        public int CurrentPage { get; set; }
        public bool GridView { get; set; }
        public string SearchQuery { get; set; }

        public IndexModel(FormaGreen.Data.FormaGreenContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int p = 1, string q = null, int grid = -1)
        {
            SearchQuery = q != null ? q : "";
            GridView = HttpContext.Session.GetInt32("grid_view").GetValueOrDefault(1) == 1;
            if (grid != -1)
            {
                GridView = grid == 1 ? true : false;
                HttpContext.Session.SetInt32("grid_view", GridView ? 1 : 0);
            }
            CurrentPage = p;
            Membres = await _context.Membres.Include(m => m.TypeMembre_).ToListAsync();
            if (q != null)
            {
                Membres = Membres.Where(m => m.Nom.ToLower().Contains(q.ToLower())).ToList();
            }
            TotalMembres = Membres.Count();
            if (CurrentPage < 1 || CurrentPage > (TotalMembres / 10 + (TotalMembres % 10 > 0 ? 1 : 0)) && q==null)
            {
                return RedirectToPage("./Index");
            }
            if (TotalMembres > 10)
            {
                Membres = Membres.Skip(10 * (CurrentPage - 1)).Take(10).ToList();
            }
            return Page();
        }
    }
}
