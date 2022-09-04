using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<ScheduledTask> ScheduledTasks { get; set; }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        //Database.EnsureCreated();
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     var passwordHash = BCrypt.Net.BCrypt.HashPassword("default");
    //     
    //     modelBuilder.Entity<User>().HasData(
    //         new User {UserId = 1, Email = "user@mail.com", PasswordHash = passwordHash});
    // }
    
}