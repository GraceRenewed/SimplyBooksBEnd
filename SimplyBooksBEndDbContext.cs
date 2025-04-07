using Microsoft.EntityFrameworkCore;
using System;
using SimplyBooksBEnd.Models;
using System.Collections.Generic;

public class SimplyBooksBEndDbContext : DbContext
{

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }

    public SimplyBooksBEndDbContext(DbContextOptions<SimplyBooksBEndDbContext> context) : base(context)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data for author
        modelBuilder.Entity<Author>().HasData(new Author[]
        {
            new Author
            {
                firebaseKey = "author1",
                UserUid = "user1",
                first_name = "Max",
                last_name = "Lucado",
                email = "maxlucado@example.com",
                favorite = true
            },
            new Author
            {
                firebaseKey = "author2",
                UserUid = "user2",
                first_name = "Francine",
                last_name = "Rivers",
                email = "francinerivers@example.com",
                favorite = true
            },
            new Author
            {
                firebaseKey = "author3",
                UserUid = "user1",
                first_name = "Karen",
                last_name = "Kingsbury",
                email = "karenkingsbury@example.com",
                favorite = false
            },
        });

        // seed data for book
        modelBuilder.Entity<Book>().HasData(new Book[]
        {
            new Book
            {
                firebaseKey = "book1",
                UserUid = "user1",
                AuthorFirebaseKey = "author1",
                title = "Grace for the Moment",
                description = "A devotional book filled with insights and reflections for daily living.",
                image = "image_url1",
                price = 12.99m,
                sale = true
            },
            new Book
            {
                firebaseKey = "book2",
                UserUid = "user2",
                AuthorFirebaseKey = "author2",
                title = "Redeeming Love",
                description = "A Christian retelling of the biblical story of Hosea and Gomer.",
                image = "image_url2",
                price = 14.99m,
                sale = false
            },
            new Book
            {
                firebaseKey = "book3",
                UserUid = "user1",
                AuthorFirebaseKey = "author3",
                title = "The Bridge",
                description = "A novel that explores faith, love, and the healing power of relationships.",
                image = "image_url3",
                price = 10.99m,
                sale = true
            },
        });

        // seed data for user
        modelBuilder.Entity<User>().HasData(new User[]
        {
            new User
            {
                uid = "user1",
                Authors = new List<Author>(),  // Will be populated later
                Books = new List<Book>(),      // Will be populated later
            },
            new User
            {
                uid = "user2",
                Authors = new List<Author>(),  
                Books = new List<Book>(),      
            }
        });
    }
}