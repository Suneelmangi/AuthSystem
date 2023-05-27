using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazerPagesDemo.Models;

namespace RazerPagesDemo.Data
{
    public class RazerPagesDemoContext : DbContext
    {
        public RazerPagesDemoContext (DbContextOptions<RazerPagesDemoContext> options)
            : base(options)
        {
        }

        public DbSet<RazerPagesDemo.Models.Students> Students { get; set; } = default!;
    }
}
