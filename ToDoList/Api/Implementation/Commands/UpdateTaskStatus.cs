using Api.Abstractions;

namespace Api.Implementation.Commands;

public class UpdateTaskStatus : ICommand
{
    private readonly int _id;
    private readonly bool _status;
    private readonly ITaskManager _taskManager;

    public UpdateTaskStatus(int id, bool status, ITaskManager taskManager)
    {
        _taskManager = taskManager;
        _id = id;
        _status = status;
    }
    
    public void Execute()
    {
        _taskManager.UpdateStatus(_id, _status);
    }
}