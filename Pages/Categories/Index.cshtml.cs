using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stavnic_Adrian_Lab2.Data;
using Stavnic_Adrian_Lab2.Models;
using Stavnic_Adrian_Lab2.ViewModels;

namespace Stavnic_Adrian_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Stavnic_Adrian_Lab2.Data.Stavnic_Adrian_Lab2Context _context;

        public IndexModel(Stavnic_Adrian_Lab2.Data.Stavnic_Adrian_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;
        public IList<Category> Category { get; set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }


        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(i => i.Books)
                    .ThenInclude(c => c.Author)
                .OrderBy(id => id.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                    .Where(i => i.ID == id.Value).Single();
               CategoryData.Books = category.Books;
            }

            if (_context.Book != null)
            {
                Book = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher).ToListAsync();
            }
        }
    }
}
