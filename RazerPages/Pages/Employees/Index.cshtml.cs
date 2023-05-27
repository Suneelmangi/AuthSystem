using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazerPages.Data;
using RazerPages.Models;

namespace RazerPages.Pages.Employee
{
    public class IndexModel : PageModel
    {
        private readonly RazerPages.Data.RazerPagesContext _context;

        public IndexModel(RazerPages.Data.RazerPagesContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Employee != null)
            {
                Employee = await _context.Employee.ToListAsync();
            }
        }
    }
}
