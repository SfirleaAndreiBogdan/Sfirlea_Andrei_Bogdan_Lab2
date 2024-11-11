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

namespace Sfirlea_Andrei_Bogdan_Lab2.Pages.Publishers
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Sfirlea_Andrei_Bogdan_Lab2.Data.Sfirlea_Andrei_Bogdan_Lab2Context _context;

        public IndexModel(Sfirlea_Andrei_Bogdan_Lab2.Data.Sfirlea_Andrei_Bogdan_Lab2Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; } = default!;
        public PublisherIndexData PublisherData { get; set; }
        public int PublisherID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id , int? bookID)
        {
            PublisherData = new PublisherIndexData();
            PublisherData.publishers = await _context.Publisher
            .Include(i => i.Books)
            .ThenInclude(c => c.Authors)
            .OrderBy(i => i.PublisherName)
            .ToListAsync();
            if (id != null)
            {
                PublisherID = id.Value;
                Publisher publisher = PublisherData.publishers
                .Where(i => i.ID == id.Value).Single();
                PublisherData.Books = publisher.Books;
            }
        }
    }
    
}
