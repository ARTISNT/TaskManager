using Api.Abstractions;

namespace Api.Implementation.Commands;

public class GetTaskById : ICommand
{
    private readonly int _id;
    private readonly ITaskManager _taskManager;

    public GetTaskById(int id, ITaskManager taskManager)
    {
        _id = id;
        _taskManager = taskManager;
    }
    
    public async Task ExecuteAsync()
    {
        await _taskManager.GetTaskById(_id);
    }
}