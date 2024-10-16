using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sfirlea_Andrei_Bogdan_Lab2.Models;

namespace Sfirlea_Andrei_Bogdan_Lab2.Data
{
    public class Sfirlea_Andrei_Bogdan_Lab2Context : DbContext
    {
        public Sfirlea_Andrei_Bogdan_Lab2Context (DbContextOptions<Sfirlea_Andrei_Bogdan_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Sfirlea_Andrei_Bogdan_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Sfirlea_Andrei_Bogdan_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Sfirlea_Andrei_Bogdan_Lab2.Models.Author> Authors { get; set; } = default!;
    }
}
