using System.Globalization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScheduledTaskController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly ITaskConverter _taskConverter;

    public ScheduledTaskController(ApplicationContext context, ITaskConverter taskConverter)
    {
        _context = context;
        _taskConverter = taskConverter;
    }

    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<ScheduledTaskDTO>> GetTasks()
    {
        var principal = HttpContext.User as ClaimsPrincipal;

        if (principal is null)
        {
            return Forbid();
        }

        var userId = 0;

        try
        {
            userId = GetUserId(principal);
        }
        catch (Exception e)
        {
            return BadRequest();
        }

        var tasks = _context.ScheduledTasks.Where(t => t.User.UserId == userId).AsEnumerable();

        var taskDto = _taskConverter.ConvertFromScheduledTasksToDtos(tasks);
        
        return Ok(taskDto);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> AddTask(ScheduledTaskDTO taskDTO)
    {
        var principal = HttpContext.User as ClaimsPrincipal;

        if (principal is null)
        {
            return Forbid();
        }
        
        var userId = 0;

        try
        {
            userId = GetUserId(principal);
        }
        catch (Exception e)
        {
            return BadRequest();
        }

        var user = await _context.Users.Where(u => u.UserId == userId).FirstOrDefaultAsync();

        try
        {
            var task = _taskConverter.ConvertFromDtoToScheduledTask(taskDTO, user);
            
            _context.ScheduledTasks.Add(task);

            await _context.SaveChangesAsync();

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }

    [Authorize]
    [HttpPut]
    public async Task<ActionResult> UpdateTask(ScheduledTaskDTO taskDTO)
    {
        var principal = HttpContext.User as ClaimsPrincipal;

        if (principal is null)
        {
            return Forbid();
        }

        string? dayString;
        var userId = 0;
        
        try
        {
            dayString = _taskConverter.GetDayString(taskDTO.ScheduledDay);
            userId = GetUserId(principal);
        }
        catch
        {
            return BadRequest();
        }

        var user = _context.Users.FirstOrDefault(u => u.UserId == userId);

        var task = _context.ScheduledTasks.FirstOrDefault(t => t.ScheduledTaskId == taskDTO.Id);

        if (task == null)
        {
            return BadRequest();
        }

        if (task.User != user)
        {
            return BadRequest();
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
            return Forbid();
        }

        var userId = 0;

        try
        {
            userId = GetUserId(principal);
        }
        catch (Exception e)
        {
            return BadRequest();
        }

        var user = _context.Users.FirstOrDefault(u => u.UserId == userId);

        var task = _context.ScheduledTasks.FirstOrDefault(t => t.ScheduledTaskId == taskDTO.Id);

        if (task == null)
        {
            return Forbid();
        }

        if (task.User != user)
        {
            return Forbid();
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
            return Forbid();
        }

        string? dayString;
        var userId = 0;
        
        try
        {
            dayString = _taskConverter.GetDayString(day);
            userId = GetUserId(principal);
        }
        catch
        {
            return BadRequest();
        }

        var tasks = _context.ScheduledTasks.Where(t => t.User.UserId == userId && t.ScheduledDay == dayString);

        return Ok(_taskConverter.ConvertFromScheduledTasksToDtos(tasks));
    }

    [Authorize]
    [HttpGet]
    [Route("month")]
    public ActionResult<IEnumerable<ScheduledTaskDTO>> GetTasksByMonth(string month)
    {
        var principal = HttpContext.User as ClaimsPrincipal;

        if (principal is null)
        {
            return Forbid();
        }

        DateTime date;
        var culture = new CultureInfo("ru-RU");

        if (!DateTime.TryParse(month, culture, DateTimeStyles.None, out date))
        {
            return BadRequest();
        }
        
        var userId = 0;

        try
        {
            userId = GetUserId(principal);
        }
        catch (Exception e)
        {
            return BadRequest();
        }

        var usersTasks = _context.ScheduledTasks.Where(t => t.User.UserId == userId);

        var dtoUsersTasks = _taskConverter.ConvertFromScheduledTasksToDtos(usersTasks);

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
}