using Api.Abstractions;
using Api.Implementation.Commands;
using Domain.Models.Entities;

namespace Api.Implementation.Factories;

public class CommandFactory : ICommandFactory
{
    private readonly ITaskManager _taskManager;

    public CommandFactory(ITaskManager taskManager)
    {
        _taskManager = taskManager;
    }


    public AddTask CreateAddTask(TaskEntity task)
    {
        return new AddTask(_taskManager, task);
    }

    public DeleteTask CreateDeleteTask(int id)
    {
        return new DeleteTask(id, _taskManager);
    }

    public GetAllTasks CreateGetAllTasks()
    {
        return new GetAllTasks(_taskManager);
    }

    public GetTaskById CreateGetTaskById(int id)
    {
        return new GetTaskById(id,  _taskManager);
    }

    public UpdateTaskStatus CreateUpdateTaskStatus(int id, bool status)
    {
        return new UpdateTaskStatus(id, status, _taskManager);
    }
}