﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stavnic_Adrian_Lab2.Models;

namespace Stavnic_Adrian_Lab2.Data
{
    public class Stavnic_Adrian_Lab2Context : DbContext
    {
        public Stavnic_Adrian_Lab2Context (DbContextOptions<Stavnic_Adrian_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Stavnic_Adrian_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Stavnic_Adrian_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Stavnic_Adrian_Lab2.Models.Author>? Author { get; set; }
        public DbSet<Stavnic_Adrian_Lab2.Models.Category>? Category { get; set; }
        public DbSet<Stavnic_Adrian_Lab2.Models.Member>? Member { get; set; }
        public DbSet<Stavnic_Adrian_Lab2.Models.Borrowing>? Borrowing { get; set; }
    }
}
