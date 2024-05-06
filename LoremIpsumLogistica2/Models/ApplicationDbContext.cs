using Microsoft.EntityFrameworkCore;

namespace LoremIpsumLogistica2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=LoremIpsumLogistica;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Enderecos)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
