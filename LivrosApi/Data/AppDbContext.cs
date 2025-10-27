using Microsoft.EntityFrameworkCore;
using LivrosApi.Models;

namespace LivrosApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<LivrosModel> Livros { get; set; }
        public DbSet<AutorModel> Autores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar o nome da tabela para "Livros" (singular)

            modelBuilder.Entity<LivrosModel>().ToTable("Livros");
            
            // Configurar a relação entre Autor e Livros
            
            modelBuilder.Entity<LivrosModel>()
                .HasOne(l => l.Autor)
                .WithMany(a => a.Livros)
                .HasForeignKey(l => l.AutorId);
        }
    }
}