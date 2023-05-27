using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazerPages.Models;

namespace RazerPages.Data
{
    public class RazerPagesContext : DbContext
    {
        public RazerPagesContext (DbContextOptions<RazerPagesContext> options)
            : base(options)
        {
        }

        public DbSet<RazerPages.Models.Employee> Employee { get; set; } = default!;
    }
}
