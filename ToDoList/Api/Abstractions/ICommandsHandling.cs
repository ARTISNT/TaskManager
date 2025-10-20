namespace Api.Abstractions;

public interface ICommandsHandling
{
    public Task ExecuteAddCommandAsync();
    public Task ExecuteGetAllCommandsAsync();
    public Task ExecuteGetTaskByIdAsync();
    public Task ExecuteUpdateStatusCommandAsync();
    public Task ExecuteDeleteCommandAsync();
}