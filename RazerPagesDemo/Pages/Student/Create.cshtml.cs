using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazerPagesDemo.Data;
using RazerPagesDemo.Models;

namespace RazerPagesDemo.Pages.Student
{
    public class CreateModel : PageModel
    {
        private readonly RazerPagesDemo.Data.RazerPagesDemoContext _context;

        public CreateModel(RazerPagesDemo.Data.RazerPagesDemoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Students Students { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //Students.AdDate = DateTime.Now;
          if (!ModelState.IsValid || _context.Students == null || Students == null)
            {
                return Page();
            }

            _context.Students.Add(Students);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
