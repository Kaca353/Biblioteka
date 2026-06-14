using Microsoft.EntityFrameworkCore;
using BibliotekaMVC.Models;

namespace BibliotekaMVC.Data
{
    public class BibliotekaContext : DbContext
    {
        public BibliotekaContext(DbContextOptions<BibliotekaContext> options)
            : base(options)
        {
        }

        public DbSet<Knjiga> Knjige { get; set; }
        public DbSet<Clan> Clanovi { get; set; }
        public DbSet<Zaduzenje> Zaduzenja { get; set; }
    }
}