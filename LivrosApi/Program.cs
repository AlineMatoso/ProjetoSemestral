using Microsoft.EntityFrameworkCore;
using LivrosApi.Data;
using LivrosApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=livros.db"));

var app = builder.Build();

// Endpoints para Livros (CÓDIGO CORRIGIDO)
app.MapGet("/livros", async (AppDbContext context) =>
    await context.Livros.Include(l => l.Autor).ToListAsync());

app.MapPost("/livros", async (LivrosModel livro, AppDbContext context) =>
{
    context.Livros.Add(livro);
    await context.SaveChangesAsync();
    return Results.Created($"/livros/{livro.Id}", livro);
});

// Endpoint GET - Buscar todos os times
app.MapGet("/", async (AppDbContext db) =>
    await db.Livros.ToListAsync()
);

app.Run();

