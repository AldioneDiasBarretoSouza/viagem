using Microsoft.EntityFrameworkCore;
using viagem.Models;

namespace vigem
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Destino> Destinos { get; set; }
    }
}
