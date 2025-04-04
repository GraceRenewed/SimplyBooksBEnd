using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimplyBooksBEnd.Models;

public class User
{
    [Key]
    public string uid { get; set; }

    public List<Author> Authors { get; set; } = new List<Author>();
    public List<Book> Books { get; set; } = new List<Book>();
}