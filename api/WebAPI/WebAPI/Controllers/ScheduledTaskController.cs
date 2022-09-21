using System.Globalization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ScheduledTaskController : ControllerBase
{
    private ApplicationContext _context;

    public ScheduledTaskController(ApplicationContext context)
    {
        _context = context;
    }

    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<ScheduledTaskDTO>> GetTasks()
    {
        var principal = HttpContext.User as ClaimsPrincipal;

        if (principal is null)
        {
            return NotFound();
        }

        var userId = GetUserId(principal);

        var tasks = _context.ScheduledTasks.Where(t => t.User.UserId == userId).AsEnumerable();

        var taskDto = ConvertToDto(tasks);
        
        return Ok(taskDto);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> AddTask(ScheduledTaskDTO taskDTO)
    {
        var principal = HttpContext.User as ClaimsPrincipal;

        if (principal is null)
        {
            return NotFound();
        }

        string? dayString;

        try
        {
            dayString = GetDayString(taskDTO.ScheduledDay);
        }
        catch
        {
            return BadRequest();
        }

        var userId = GetUserId(principal);

        var user = _context.Users.Where(u => u.UserId == userId).First();

        var task = new ScheduledTask {
            Name = taskDTO.Name,
            Description = taskDTO.Description,
            User = user,
            ScheduledDay = dayString
        };

        _context.ScheduledTasks.Add(task);

        await _context.SaveChangesAsync();

        return Ok();
    }

    [Authorize]
    [HttpPut]
    public async Task<ActionResult> UpdateTask(ScheduledTaskDTO taskDTO)
    {
        var principal = HttpContext.User as ClaimsPrincipal;

        if (principal is null)
        {
            return NotFound();
        }

        string? dayString;

        try
        {
            dayString = GetDayString(taskDTO.ScheduledDay);
        }
        catch
        {
            return BadRequest();
        }

        var userId = GetUserId(principal);

        var user = _context.Users.FirstOrDefault(u => u.UserId == userId);

        var task = _context.ScheduledTasks.FirstOrDefault(t => t.ScheduledTaskId == taskDTO.Id);

        if (task == null)
        {
            return NotFound();
        }

        if (task.User != user)
        {
            return NotFound();
        }

        task.Name = taskDTO.Name;
        task.Description = taskDTO.Description;
        task.ScheduledDay = dayString;

        await _context.SaveChangesAsync();

        return Ok();
    }

    [Authorize]
    [HttpDelete]
    public async Task<ActionResult> DeleteTask(ScheduledTaskDTO taskDTO)
    { 
        var principal = HttpContext.User as ClaimsPrincipal;

        if (principal is null)
        {
            return NotFound();
        }

        var userId = GetUserId(principal);

        var user = _context.Users.FirstOrDefault(u => u.UserId == userId);

        var task = _context.ScheduledTasks.FirstOrDefault(t => t.ScheduledTaskId == taskDTO.Id);

        if (task == null)
        {
            return NotFound();
        }

        if (task.User != user)
        {
            return NotFound();
        }

        _context.ScheduledTasks.Remove(task);

        await _context.SaveChangesAsync();

        return Ok();
    }

    [Authorize]
    [HttpGet]
    [Route("day")]
    public ActionResult<IEnumerable<ScheduledTaskDTO>> GetTasksByDay(string day)
    {
        var principal = HttpContext.User as ClaimsPrincipal;

        if (principal is null)
        {
            return NotFound();
        }

        string? dayString;

        try
        {
            dayString = GetDayString(day);
        }
        catch
        {
            return BadRequest();
        }

        var userId = GetUserId(principal);

        var tasks = _context.ScheduledTasks.Where(t => t.User.UserId == userId && t.ScheduledDay == dayString);

        return Ok(ConvertToDto(tasks));
    }

    [Authorize]
    [HttpGet]
    [Route("month")]
    public ActionResult<IEnumerable<ScheduledTaskDTO>> GetTasksByMonth(string month)
    {
        var principal = HttpContext.User as ClaimsPrincipal;

        if (principal is null)
        {
            return NotFound();
        }

        DateTime date;
        var culture = new CultureInfo("ru-RU");

        if (!DateTime.TryParse(month, culture, DateTimeStyles.None, out date))
        {
            return BadRequest();
        }
        
        var userId = GetUserId(principal);

        var usersTasks = _context.ScheduledTasks.Where(t => t.User.UserId == userId);

        var dtoUsersTasks = ConvertToDto(usersTasks);

        var resultTasks = dtoUsersTasks.Where(t =>
        {
            if (t.ScheduledDay is null)
            {
                return false;
            }
        
            var taskDate = DateTime.Parse(t.ScheduledDay, culture);
        
            return date.Year == taskDate.Year && date.Month == taskDate.Month;
        });

        return Ok(resultTasks);
    }

    private int GetUserId(ClaimsPrincipal principal)
    {
        if (principal.HasClaim(x => x.Type == ClaimTypes.NameIdentifier))
        {
            var claim = principal.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).First();
            return int.Parse(claim.Value);
        }
        else
        {
            throw new Exception("UserId not found in claims");
        }
    }

    private IEnumerable<ScheduledTaskDTO> ConvertToDto(IEnumerable<ScheduledTask> scheduledTasks)
    {
        var result = new List<ScheduledTaskDTO>();

        foreach (var task in scheduledTasks)
        {
            var taskDto = new ScheduledTaskDTO {
                Id = task.ScheduledTaskId,
                Name = task.Name,
                Description = task.Description,
                ScheduledDay = task.ScheduledDay
            };

            result.Add(taskDto);
        }

        return result;
    }
    
    private string? GetDayString(string? userString)
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
            throw new Exception();
        }
        else
        {
            dayString = day.ToString("d", culture);
        }

        return dayString;
    }
}