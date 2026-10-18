using Microsoft.EntityFrameworkCore;
using Petreus_Mihaela_Lab2.Models;

namespace Petreus_Mihaela_Lab2
{
    public class Petreus_Mihaela_Lab2Context : DbContext
    {
        public Petreus_Mihaela_Lab2Context(DbContextOptions<Petreus_Mihaela_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<Publisher> Publisher { get; set; } = default!;
        public DbSet<Author> Author { get; set; } = default!;
    }
}