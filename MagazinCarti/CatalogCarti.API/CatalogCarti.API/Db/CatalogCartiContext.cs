using CatalogCarti.API.Model;
using Microsoft.EntityFrameworkCore;

namespace CatalogCarti.API.Db
{
    //Extindem clasa DbContext din Entity Framework
    public class CatalogCartiContext : DbContext
    {
        //Configuram contextul in care ne aflam
        public CatalogCartiContext(DbContextOptions<CatalogCartiContext> options) : base(options)
        {

        }

        //Rescriem aceasta metoda pentru a configura baza de date care va fi folosita in context
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        //Declaram felul in care vom comunica cu tabela Carti
        public DbSet<Carte> Carti { get; set; }

    }
}
