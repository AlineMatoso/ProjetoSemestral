using Microsoft.EntityFrameworkCore;
using TesteApiBiblioteca.Models;

namespace TesteApiBiblioteca.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<AutorModel> Autores => Set<AutorModel>();
        public DbSet<LivroModel> Livros => Set<LivroModel>();
    }
}