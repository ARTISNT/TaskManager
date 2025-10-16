using Api.Abstractions;

namespace Api.Implementation.Commands;

public class GetAllTasks : ICommand
{
    private readonly ITaskManager _taskManager;

    public GetAllTasks(ITaskManager taskManager)
    {
        _taskManager = taskManager;
    }

    public void Execute()
    {
        _taskManager.GetAllTasks();    
    }
}