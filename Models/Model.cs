using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    // Optionally, override OnConfiguring if not using dependency injection
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseSqlite("Data Source=localdb.db");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure one-to-many relationship between user and session
        modelBuilder.Entity<User>()
            .HasMany(u => u.Sessions)
            .WithOne(s => s.User)
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade); // Optional: configure delete behavior

        // Other configurations if needed
        base.OnModelCreating(modelBuilder);

        // Seed Users
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Username = "admin",
                Email = "admin@example.com",
                PasswordHash = "hashed-password",
                FirstName = "Admin",
                LastName = "User",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new User
            {
                Id = 2,
                Username = "user",
                Email = "user@example.com",
                PasswordHash = "hashed-password",
                FirstName = "Regular",
                LastName = "User",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        );
    }
}

[Table("Users")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

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

    // Navigation property for related sessions
    public ICollection<Session> Sessions { get; set; } = new List<Session>();
    // parameterless constructor
    public User()
    {
    }
}

[Table("Sessions")]
public class Session
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

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

    // Navigation property
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    // parameterless constructor
    public Session()
    {
    }
}