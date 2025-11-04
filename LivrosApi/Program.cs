using LivrosApi.Controllers;
using LivrosApi.Controllers.AutorService;
using LivrosApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=biblioteca.db"));

builder.Services.AddControllers();

builder.Services.AddScoped<AutorInterface, AutorService>(); // comunicação entre autoriservice e autor interface

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.MapGet("/autores", async (AppDbContext db) =>
    await db.Autores.ToListAsync());


app.Run();
