namespace WebAPI.Models;

public class ScheduledTaskDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ScheduledDay { get; set; }
    public string? RepeatType { get; set; }
}