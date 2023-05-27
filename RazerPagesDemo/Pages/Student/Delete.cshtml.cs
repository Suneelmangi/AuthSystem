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
    public class DeleteModel : PageModel
    {
        private readonly RazerPagesDemo.Data.RazerPagesDemoContext _context;

        public DeleteModel(RazerPagesDemo.Data.RazerPagesDemoContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Students Students { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var students = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);

            if (students == null)
            {
                return NotFound();
            }
            else 
            {
                Students = students;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }
            var students = await _context.Students.FindAsync(id);

            if (students != null)
            {
                Students = students;
                _context.Students.Remove(Students);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
