using SimplyBooksBEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<SimplyBooksBEndDbContext>(builder.Configuration["SimplyBooksBEndDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/authors", (SimplyBooksBEndDbContext db) =>
{
    return db.Authors.ToList();
});

app.MapGet("authors/{userUid}", (SimplyBooksBEndDbContext db, string userUid) =>
{
    return db.Authors
        .Include(a => a.Books)
        .Where(a => a.UserUid == userUid)
        .ToList();
});

app.MapPost("/authors", (SimplyBooksBEndDbContext db, Author author) =>
{
    db.Authors.Add(author);
    db.SaveChanges();
    return Results.Created($"/authors/{author.firebaseKey}", author);
});

app.MapDelete("/authors/{firebaseKey}", (SimplyBooksBEndDbContext db, string firebaseKey) =>
{
    Author author = db.Authors.SingleOrDefault(author => author.firebaseKey == firebaseKey);
    if (author == null)
    {
        return Results.NotFound();
    }
    db.Authors.Remove(author);
    db.SaveChanges();
    return Results.NoContent();

});

app.MapGet("/books", (SimplyBooksBEndDbContext db) =>
{
    return db.Books
        .Include(a => a.Author)
        .ToList();
});

app.MapGet("books/{userUid}", (SimplyBooksBEndDbContext db, string userUid) =>
{
    return db.Books
        .Include(a => a.Author)
        .Where(a => a.UserUid == userUid)
        .ToList();
});

// .WithName("GetWeatherForecast")
// .WithOpenApi();

app.Run();

