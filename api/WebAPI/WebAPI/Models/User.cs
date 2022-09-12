using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;

public class User
{
    public int UserId { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public virtual List<ScheduledTask> ScheduledTasks { get; set; }
}
