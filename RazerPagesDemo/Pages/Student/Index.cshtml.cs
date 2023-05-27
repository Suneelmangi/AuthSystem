using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazerPagesDemo.Data;
using RazerPagesDemo.Models;

namespace RazerPagesDemo.Pages.Student
{
    public class IndexModel : PageModel
    {
        private readonly RazerPagesDemo.Data.RazerPagesDemoContext _context;

        public IndexModel(RazerPagesDemo.Data.RazerPagesDemoContext context)
        {
            _context = context;
        }

        public IList<Students> Students { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Students != null)
            {
                Students = await _context.Students.ToListAsync();
            }
        }
    }
}
