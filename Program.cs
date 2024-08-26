using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using pisofinderapi.Data;

Console.WriteLine("application started!");

var builder = WebApplication.CreateBuilder(args);

// Configure the DbContext with SQL Server
builder.Services.AddDbContext<PisoFinderContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PisoFinderContext")
    ?? throw new InvalidOperationException("Connection string 'PisoFinderContext' not found.")));

Console.WriteLine("passed the connection!");

// Add services to the container
builder.Services.AddControllers(); // Registers controllers as services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers(); // Maps attribute-routed controllers

Console.WriteLine("application final!");

app.Run();