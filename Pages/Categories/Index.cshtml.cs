using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sfirlea_Andrei_Bogdan_Lab2.Data;
using Sfirlea_Andrei_Bogdan_Lab2.Models;
using Sfirlea_Andrei_Bogdan_Lab2.Models.ViewModels;

namespace Sfirlea_Andrei_Bogdan_Lab2.Pages.Categories
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Sfirlea_Andrei_Bogdan_Lab2.Data.Sfirlea_Andrei_Bogdan_Lab2Context _context;

        public IndexModel(Sfirlea_Andrei_Bogdan_Lab2.Data.Sfirlea_Andrei_Bogdan_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;
        
        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoryIndexData();
             CategoryData.Categories = await _context.Category
            .Include(i => i.BookCategories)
            .ThenInclude(c => c.Book)
            .ThenInclude(c => c.Authors)
            .OrderBy(i => i.CategoryName)
            .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                .Where(i => i.Id == id.Value).Single();
                CategoryData.Books = category.BookCategories.Select(b => b.Book);
            }

        }
    }
}
