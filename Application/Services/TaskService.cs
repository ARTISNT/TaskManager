using Application.Abstractions;
using Domain.Models.Entities;
using Infrastructure.Abstractions.Repositories;

namespace Application.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<IEnumerable<TaskEntity>> GetAll()
    {
        return await _taskRepository.GetAll();
    }

    public async Task<TaskEntity?> GetById(int id)
    {
        IdValidate(id);
        return await _taskRepository.GetById(id);
    }

    public async Task Create(TaskEntity task)
    {
        TaskValidate(task);
        
        task.CreatedAt = DateTime.UtcNow;
        task.IsCompleted = false;
            
        await _taskRepository.Create(task);
    }
    
    public async Task UpdateStatus(int id, bool taskStatus)
    {
        IdValidate(id);
        await CheckEntityForExist(id);
        await _taskRepository.UpdateStatus(id,  taskStatus);
    }

    public async Task Delete(int id)
    {
        IdValidate(id);
        await CheckEntityForExist(id);
        await _taskRepository.Delete(id);
    }

    private void IdValidate(int id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id));
    }

    private async Task CheckEntityForExist(int id)            
    {
        if (await _taskRepository.GetById(id) == null)
            throw new InvalidOperationException($"Task with id:{id} not found");
    }
    
    private void TaskValidate(TaskEntity task)
    {
        ArgumentNullException.ThrowIfNull(task);

        if (string.IsNullOrWhiteSpace(task.Title))
            throw new ArgumentException($"Title cannot be empty");
    }
}