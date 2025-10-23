using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LivrosApi.Data
{
    public class AppDbContext 
    {
        public AppDbContext(DbContextOptions<AppContext> options) : base(options)
        {

        }
        
        public DbSet<AutorModel> Autores{ get; set;  } //forma para criaçao da tabela de autor
    }
}