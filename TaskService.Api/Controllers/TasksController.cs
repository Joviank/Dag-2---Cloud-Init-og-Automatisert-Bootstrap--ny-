using Microsoft.AspNetCore.Mvc;
using TaskService;
using TaskService.Api.DTO;

namespace TaskService.Api.Controllers;

[ApiController]
[Route("tasks")]
public class TasksController : ControllerBase
{
    private readonly TaskService _taskService;

    public TasksController(TaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public IEnumerable<TaskItem> GetTasks()
    {
        return _taskService.GetTasks();
    }

    [HttpPost]
    public TaskItem AddTask([FromBody] CreateTaskRequest request)
    {
        return _taskService.AddTask(request.Title);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        _taskService.DeleteTask(id);
        return NoContent();
    }
}