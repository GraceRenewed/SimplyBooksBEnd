using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimplyBooksBEnd.Models;

public class Author
{
    [Key]
    public string firebaseKey { get; set; }
    [Required]
    public string UserUid { get; set; }
    public User User { get; set; }
    public string first_name { get; set; }
    [Required]
    public string last_name { get; set; }
    public string? email { get; set; }
    public bool favorite { get; set; }
}