
using Microsoft.EntityFrameworkCore;
using LivrosApi.Data;

var builder = WebApplication.CreateBuilder(args); // Inicializa a configuração base da aplicação ASP.NET Core,
//  permitindo registrar serviços, configurações e logs antes de construir e rodar o servidor


// Configurar o SQLite
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=livros.db"));

var app = builder.Build();
// builder é um modo de configuração
// app é um modo de execução

app.MapGet("/", () => "Hello World!");

app.Run();
