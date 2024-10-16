using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sfirlea_Andrei_Bogdan_Lab2.Data;
using Sfirlea_Andrei_Bogdan_Lab2.Models;

namespace Sfirlea_Andrei_Bogdan_Lab2.Pages.Authors
{
    public class CreateModel : PageModel
    {
        private readonly Sfirlea_Andrei_Bogdan_Lab2.Data.Sfirlea_Andrei_Bogdan_Lab2Context _context;

        public CreateModel(Sfirlea_Andrei_Bogdan_Lab2.Data.Sfirlea_Andrei_Bogdan_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Author Authors { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingFirstName = await _context.Authors
            .FirstOrDefaultAsync(b => b.FirstName == Authors.FirstName);

            var existingLastName = await _context.Authors
            .FirstOrDefaultAsync(b => b.LastName == Authors.LastName);


            if (existingFirstName != null && existingLastName != null)
            {
                throw new Exception("An author with this name already exists.");
            }

            _context.Authors.Add(Authors);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
