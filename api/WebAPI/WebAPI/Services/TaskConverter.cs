using System.Globalization;
using WebAPI.Models;

namespace WebAPI.Services;

public class TaskConverter : ITaskConverter
{
    public IEnumerable<ScheduledTaskDTO> ConvertFromScheduledTasksToDtos(IEnumerable<ScheduledTask> scheduledTasks)
    {
        var result = new List<ScheduledTaskDTO>();

        foreach (var task in scheduledTasks)
        {
            var taskDto = new ScheduledTaskDTO {
                Id = task.ScheduledTaskId,
                Name = task.Name,
                Description = task.Description,
                ScheduledDay = task.ScheduledDay,
                RepeatType = Enum.GetName(typeof(RepeatType), task.RepeatType)
            };

            result.Add(taskDto);
        }

        return result;
    }

    public ScheduledTask ConvertFromDtoToScheduledTask(ScheduledTaskDTO scheduledTaskDto, User? user)
    {
        var scheduledDay = GetDayString(scheduledTaskDto.ScheduledDay);

        RepeatType repeatType;

        if (!Enum.TryParse(scheduledTaskDto.RepeatType, true, out repeatType))
            throw new ArgumentException();

        return new ScheduledTask()
        {
            Name = scheduledTaskDto.Name,
            Description = scheduledTaskDto.Description,
            ScheduledDay = scheduledDay,
            RepeatType = repeatType,
            User = user
        };
    }

    public string? GetDayString(string? userString)
    {
        DateTime day;
        string? dayString;
        var culture = new CultureInfo("ru-RU");

        if (userString == null)
        {
            dayString = null;
        }
        else if (!DateTime.TryParseExact(userString, "d", culture, DateTimeStyles.None, out day))
        {
            throw new ArgumentException();
        }
        else
        {
            dayString = day.ToString("d", culture);
        }

        return dayString;
    }
}