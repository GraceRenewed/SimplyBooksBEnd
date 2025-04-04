using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimplyBooksBEnd.Models;

public class Book
{
    [Key]
    public string firebaseKey { get; set; }

    [Required]
    public string UserUid { get; set; }
    public User User { get; set; }

    public string AuthorFirebaseKey { get; set; }
    public Author Author { get; set; }

    public string title { get; set; }
    public string? description { get; set; }
    public string? image { get; set; }

    public decimal? price { get; set; }
    public bool sale { get; set; }
}