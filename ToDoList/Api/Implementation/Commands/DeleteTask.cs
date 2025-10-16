using Api.Abstractions;

namespace Api.Implementation.Commands;

public class DeleteTask : ICommand
{
    private readonly int _id;
    private readonly ITaskManager _taskManager;

    public DeleteTask(int id, ITaskManager taskManager)
    {
        _id = id;
        _taskManager = taskManager;
    }
    
    public void Execute()
    {
        _taskManager.RemoveTask(_id);
    }
}