using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class ScheduledTaskController : ControllerBase
{
    private ApplicationContext _context;

    public ScheduledTaskController(ApplicationContext context)
    {
        _context = context;
    }

    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<ScheduledTask>> GetTasks()
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
    public ActionResult AddTask(ScheduledTaskDTO taskDTO)
    {
        var principal = HttpContext.User as ClaimsPrincipal;

        if (principal is null)
        {
            return NotFound();
        }

        var userId = GetUserId(principal);

        var user = _context.Users.Where(u => u.UserId == userId).First();

        var task = new ScheduledTask {Name = taskDTO.Name, Description = taskDTO.Description, User = user};

        if (user.ScheduledTasks is null)
        {
            user.ScheduledTasks = new List<ScheduledTask>();
        }
        
        user.ScheduledTasks.Add(task);

        _context.SaveChanges();

        return Ok();
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
            var taskDto = new ScheduledTaskDTO {Name = task.Name, Description = task.Description};
            result.Add(taskDto);
        }

        return result;
    }
    
}