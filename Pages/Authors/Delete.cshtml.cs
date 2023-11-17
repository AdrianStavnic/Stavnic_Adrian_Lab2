using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stavnic_Adrian_Lab2.Data;
using Stavnic_Adrian_Lab2.Models;

namespace Stavnic_Adrian_Lab2.Pages.Authors
{
    public class DeleteModel : PageModel
    {
        private readonly Stavnic_Adrian_Lab2.Data.Stavnic_Adrian_Lab2Context _context;

        public DeleteModel(Stavnic_Adrian_Lab2.Data.Stavnic_Adrian_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Author Authors { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Author== null)
            {
                return NotFound();
            }

            var authors = await _context.Author.FirstOrDefaultAsync(m => m.ID == id);

            if (authors == null)
            {
                return NotFound();
            }
            else 
            {
                Authors = authors;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Author == null)
            {
                return NotFound();
            }
            var authors = await _context.Author.FindAsync(id);

            if (authors != null)
            {
                Authors = authors;
                _context.Author.Remove(Authors);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
