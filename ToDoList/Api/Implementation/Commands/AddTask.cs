using Api.Abstractions;
using Domain.Models.Entities;

namespace Api.Implementation.Commands;

public class AddTask : ICommand
{
    private readonly ITaskManager _taskManager;
    private TaskEntity _task;

    public AddTask(ITaskManager taskManager, TaskEntity task)
    {
        _taskManager = taskManager;
        _task = task;
    }

    public async Task ExecuteAsync()
    {
        await _taskManager.AddTask(_task);
    }
}