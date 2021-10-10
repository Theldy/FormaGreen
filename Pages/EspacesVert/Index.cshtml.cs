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

namespace FormaGreen.Pages.EspacesVert
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly FormaGreen.Data.FormaGreenContext _context;
        public List<EspaceVert> Espaces { get; set; }
        public int TotalEspaces { get; set; }
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
            Espaces = await _context.Espaces_Vert.ToListAsync();
            if (q != null)
            {
                Espaces = Espaces.Where(m => m.Etablissement.ToLower().Contains(q.ToLower())).ToList();
            }
            TotalEspaces = Espaces.Count();
            if (CurrentPage < 1 || CurrentPage > (TotalEspaces / 10 + (TotalEspaces % 10 > 0 ? 1 : 0)) && q==null)
            {
                return RedirectToPage("./Index");
            }
            if (TotalEspaces > 10)
            {
                Espaces = Espaces.Skip(10 * (CurrentPage - 1)).Take(10).ToList();
            }
            return Page();
        }
    }
}
