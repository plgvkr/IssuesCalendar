using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;

public class ScheduledTask
{
    public int ScheduledTaskId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ScheduledDay { get; set; }
    public RepeatType RepeatType { get; set; }
    
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
}

public enum RepeatType
{
    None,
    Everyday,
    Everyweek,
    Everymonth,
    Everyyear
}