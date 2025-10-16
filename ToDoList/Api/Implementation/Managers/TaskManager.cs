using Api.Abstractions;
using Application.Services;
using Domain.Models.Entities;

namespace Api.Implementation.Managers;

public class TaskManager : ITaskManager
{
    private readonly TaskService _taskService;

    public TaskManager(TaskService taskService)
    {
        _taskService = taskService;
    }
    
    public async Task GetAllTasks()
    {
        var tasks = await _taskService.GetAll();

        foreach (var task in tasks)
        {
            Console.WriteLine($"Task: {task.Title}\n" +
                              $"Description: {task.Description}\n" +
                              $"IsCompleted: {task.IsCompleted}\n" +
                              $"CreatedAt: {task.CreatedAt}\n\n");
        }
    }

    public async Task GetTaskById(int taskId)
    {
        var task = await _taskService.GetById(taskId);
        
        Console.WriteLine($"Task: {task.Title}\n" +
                          $"Description: {task.Description}\n" +
                          $"IsCompleted: {task.IsCompleted}\n" +
                          $"CreatedAt: {task.CreatedAt}\n\n");
    }

    public async Task RemoveTask(int id)
    {
        await _taskService.Delete(id);
        Console.WriteLine($"Task was deleted.");
    }

    public async Task AddTask(TaskEntity task)
    {
        await _taskService.Create(task);
        Console.WriteLine($"Task was added.");
    }

    public async Task UpdateStatus(int taskId, bool status)
    {
        await _taskService.UpdateStatus(taskId, status);
        Console.WriteLine($"Staus of task was updated to {status}.");
    }
}