using Microsoft.EntityFrameworkCore;
using Lab2.Controllers;
using Lab2.DataService;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



// Get the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection");

// Add the DbContext service with the SQL Server connection
builder.Services.AddDbContext<LabContext>(options => options.UseSqlServer(connectionString));


// Get the MongoDB connection string from appsettings.json
var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDBConnection");
MongoClient mongoClient = new MongoClient(mongoConnectionString);


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
