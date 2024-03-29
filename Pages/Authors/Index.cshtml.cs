﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly Stavnic_Adrian_Lab2.Data.Stavnic_Adrian_Lab2Context _context;

        public IndexModel(Stavnic_Adrian_Lab2.Data.Stavnic_Adrian_Lab2Context context)
        {
            _context = context;
        }

        public IList<Author> Authors { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Authors != null)
            {
                Authors = await _context.Authors.ToListAsync();
            }
        }
    }
}
