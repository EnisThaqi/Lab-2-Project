using Microsoft.EntityFrameworkCore;
using Lab2.Controllers;
using Lab2.DataService;
using Lab2.Models;
using Lab2.ModelsMongo;
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
builder.Services.AddScoped<UserService, UserService>();



// Get the MongoDB connection string from appsettings.json
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<MongoDBContext>();


// Enable Cors
builder.Services.AddCors(p => p.AddPolicy("", build =>
{
    build.WithOrigins("").AllowAnyMethod().AllowAnyHeader();
}));
// enable single domain
// multiple domain
// any domain

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
