namespace Api.Abstractions;

public interface ICommand
{
    public Task ExecuteAsync();
}