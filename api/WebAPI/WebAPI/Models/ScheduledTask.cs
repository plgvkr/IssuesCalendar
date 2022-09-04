using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;

public class ScheduledTask
{
    public int ScheduledTaskId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
}