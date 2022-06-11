using Comenzi.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Comenzi.API.Db
{
    public class ComandaContext : DbContext
    {
        public ComandaContext(DbContextOptions<ComandaContext> options) : base(options)
        {
        }
        public DbSet<Comanda> Comanda { get; set; }


    }
}
