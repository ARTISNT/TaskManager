using Domain.Models.Entities;

namespace Application.Abstractions;

public interface ITaskService
{
    public Task<IEnumerable<TaskEntity>> GetAll();
    public Task<TaskEntity?> GetById(int id);
    public Task Create(TaskEntity task);
    public Task UpdateStatus(int id, bool taskStatus);
    public Task Delete(int id);
}