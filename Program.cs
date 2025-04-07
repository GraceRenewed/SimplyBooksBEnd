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

app.MapGet("author/{firebaseKey}", (SimplyBooksBEndDbContext db, string firebaseKey) =>
{
    return db.Authors
    .Include(a => a.Books)
    .Where(a => a.firebaseKey == firebaseKey)
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

app.MapPut("/authors/{firebaseKey}", (SimplyBooksBEndDbContext db, string firebaseKey, Author author) =>
{
    Author authorToUpdate = db.Authors.SingleOrDefault(author => author.firebaseKey == firebaseKey);
    if (authorToUpdate == null)
    {
        return Results.NotFound();
    }
    authorToUpdate.first_name = author.first_name;
    authorToUpdate.last_name = author.last_name;
    authorToUpdate.email = author.email;
    authorToUpdate.favorite = author.favorite;

    db.SaveChanges();
    return Results.NoContent();
});

app.MapGet("/books", (SimplyBooksBEndDbContext db) =>
{
    return db.Books
        .Include(a => a.Author)
        .ToList();
});

app.MapGet("book/{firebaseKey}", (SimplyBooksBEndDbContext db, string firebaseKey) =>
{
    return db.Books
        .Include(a => a.Author)
        .Where(a => a.firebaseKey == firebaseKey)
        .ToList();
});

app.MapPost("/books", (SimplyBooksBEndDbContext db, Book book) =>
{
    db.Books.Add(book);
    db.SaveChanges();
    return Results.Created($"/books/{book.firebaseKey}", book);
});

app.MapDelete("/books/{firebaseKey}", (SimplyBooksBEndDbContext db, string firebaseKey) =>
{
    Book book = db.Books.SingleOrDefault(book => book.firebaseKey == firebaseKey);
    if (book == null)
    {
        return Results.NotFound();
    }
    db.Books.Remove(book);
    db.SaveChanges();
    return Results.NoContent();

});

app.MapPut("/books/{firebaseKey}", (SimplyBooksBEndDbContext db, string firebaseKey, Book book) =>
{
    Book bookToUpdate = db.Books.SingleOrDefault(book => book.firebaseKey == firebaseKey);
    if (bookToUpdate == null)
    {
        return Results.NotFound();
    }
    bookToUpdate.AuthorFirebaseKey = book.AuthorFirebaseKey;
    bookToUpdate.title = book.title;
    bookToUpdate.description = book.description;
    bookToUpdate.image = book.image;
    bookToUpdate.price = book.price;
    bookToUpdate.sale = book.sale;

    db.SaveChanges();
    return Results.NoContent();
});

app.MapGet("user/books{userUid}", (SimplyBooksBEndDbContext db, string userUid) =>
{
    return db.Books
        .Where(a => a.UserUid == userUid)
        .ToList();
});

app.MapGet("user/authors{userUid}", (SimplyBooksBEndDbContext db, string userUid) =>
{
    return db.Authors
        .Where(a => a.UserUid == userUid)
        .ToList();
});
// .WithName("GetWeatherForecast")
// .WithOpenApi();

app.Run();

