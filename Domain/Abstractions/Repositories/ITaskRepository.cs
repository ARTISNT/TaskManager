using Domain.Models.Entities;

namespace Infrastructure.Abstractions.Repositories;

public interface ITaskRepository
{
    public Task<IEnumerable<TaskEntity>> GetAll();
    public Task<TaskEntity?> GetById(int id);
    public Task Create(TaskEntity task);
    public Task UpdateStatus(int id, bool status);
    public Task Delete(int id);
}