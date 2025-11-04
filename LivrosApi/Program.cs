using LivrosApi.Controllers;
using LivrosApi.Controllers.AutorService;
using LivrosApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=biblioteca.db"));

builder.Services.AddControllers();

builder.Services.AddScoped<AutorInterface, AutorService>(); // comunicação entre autoriservice e autor interface


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
