using Dapper;
using Domain.Models.Entities;
using Infrastructure.Abstractions.Repositories;
using Infrastructure.Abstractions.Factory;

namespace Infrastructure.Implementation.Repositories;
public class TaskRepository : ITaskRepository
{
    private readonly ICreatorOfConnection _sqlConnectionCreator;

    public TaskRepository(ICreatorOfConnection sqlConnectionCreator)
    {
        _sqlConnectionCreator = sqlConnectionCreator;
    }

    public async Task<IEnumerable<TaskEntity>> GetAll()
    {
        const string sql = "SELECT * FROM [Tasks]";
        await using var connection = _sqlConnectionCreator.CreateConnection();
        
        return await connection.QueryAsync<TaskEntity>(sql);
    }

    public async Task<TaskEntity?> GetById(int id)
    {
        const string sql = "SELECT * FROM [Tasks] WHERE Id = @Id";
        await using var connection = _sqlConnectionCreator.CreateConnection();
        
        return await connection.QueryFirstOrDefaultAsync<TaskEntity>(sql, new { Id = id });
    }

    public async Task Create(TaskEntity task)
    {
        const string sql = "INSERT INTO [Tasks] (Title, Description, IsCompleted, CreatedAt) VALUES (@Title, @Description, @IsCompleted, @CreatedAt)";
        
        await using var connection = _sqlConnectionCreator.CreateConnection();
        await connection.ExecuteAsync(sql, task);
    }

    public async Task UpdateStatus(int id, bool status)
    {
        const string sql = "UPDATE [Tasks] SET IsCompleted = @IsCompleted WHERE Id = @Id";
        await using var connection = _sqlConnectionCreator.CreateConnection();
        
        var affectedRows = await connection.ExecuteAsync(sql, new { Id = id, IsCompleted = status });
    }

    public async Task Delete(int id)
    {
        const string sql = "DELETE FROM [Tasks] WHERE Id = @Id";
        
        await using var connection = _sqlConnectionCreator.CreateConnection();
        await connection.ExecuteAsync(sql, new { Id = id });
    }
}
