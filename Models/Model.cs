using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Session> Sessions { get; set; }
}

[Table("Users")]ß
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    [Required]
    [MaxLength(255)]
    public string Username { get; set; }

    [Required]
    [MaxLength(255)]
    public string Email { get; set; }

    [Required]
    [MaxLength(512)]
    public string PasswordHash { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; }

    [MaxLength(100)]
    public string LastName { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public User(string username, string email, string firstname, string lastname, string passwordhash)
    {
        Username = username;
        Email = email;
        FirstName = firstname;
        LastName = lastname;
        PasswordHash = passwordhash;
    }
}

[Table("Sessions")]
public class Session
{
    [Key]
    public Guid SessionId { get; set; } = Guid.NewGuid();

    public int UserId { get; set; }
    public int ApplicationId { get; set; }

    [Required]
    [MaxLength(512)]
    public string Token { get; set; }

    [Required]
    [MaxLength(50)]
    public string Status { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? ExpiresAt { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }

    public Session(string token, string status, User user)
    {
        Token = token;
        Status = status;
        User = user;
    }
}