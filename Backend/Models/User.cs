using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class User
{
    public int Id { get; set; }

    [Required] public string Username { get; set; }

    [Required] public string Password { get; set; }
}