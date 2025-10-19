using Api.Implementation.Commands;
using Domain.Models.Entities;

namespace Api.Abstractions;

public interface ITaskManager
{
    public Task GetAllTasks();
    public Task GetTaskById(int taskId);
    public Task RemoveTask(int id);
    public Task AddTask(TaskEntity task);
    public Task UpdateStatus(int taskId, bool status);
}