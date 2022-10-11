using Microsoft.EntityFrameworkCore;
using BookManagerApi.Models;
using BookManagerApi.Services;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BookManagerApi");
// Add services to the container.

builder.Services.AddScoped<IBookManagementService, BookManagementService>();
builder.Services.AddControllers();
builder.Services.AddDbContext<BookContext>(option =>
   option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Configure Swagger/OpenAPI DocumentationMySqlConnector.MySqlException: 'Access denied for user 'bookmanagerapi'@'localhost' (using password: YES)'
// You can learn more on this link: https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

