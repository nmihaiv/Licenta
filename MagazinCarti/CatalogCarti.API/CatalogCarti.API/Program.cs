using CatalogCarti.API.Db;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

// Adaugam contextul Entity Framework in colectia de servicii
// Declaram ca vom folosi o baza de date in memoria calulatorului
builder.Services.AddDbContext<CatalogCartiContext>(opt => opt.UseInMemoryDatabase("CatalogCartiDB"));


//Adaugam Swagger la proiect pentru a avea o interfata vizuala.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuram apelurile HTTP 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
