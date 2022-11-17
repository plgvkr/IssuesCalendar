using WebAPI.Models;

namespace WebAPI.Services;

public interface ITaskConverter
{
    public IEnumerable<ScheduledTaskDTO> ConvertFromScheduledTasksToDtos(IEnumerable<ScheduledTask> scheduledTasks);

    public ScheduledTask ConvertFromDtoToScheduledTask(ScheduledTaskDTO scheduledTaskDto, User? user);

    public string? GetDayString(string? userString);
}