using Api.Abstractions;
using Domain.Models.Entities;

namespace Api.Implementation.UI;

public class CommandsHandling : ICommandsHandling
{
    private readonly ICommandFactory _commandFactory;

    public CommandsHandling(ICommandFactory commandFactory)
    {
        _commandFactory = commandFactory;
    }

    public async Task ExecuteAddCommandAsync()
    {
        Console.WriteLine("Description:");
        string description = Console.ReadLine();

        Console.WriteLine("Title:");
        string title = Console.ReadLine();

        TaskEntity task = new TaskEntity()
        {
            Description = description,
            Title = title,
        };

        var command = _commandFactory.CreateAddTask(task);
        await command.ExecuteAsync();
    }

    public async Task ExecuteGetAllCommandsAsync()
    {
        var command = _commandFactory.CreateGetAllTasks();
        await command.ExecuteAsync();
    }

    public async Task ExecuteGetTaskByIdAsync()
    {
        var id = ReadValue<int>("Write id", "Invalid id", int.TryParse);

        var command = _commandFactory.CreateGetTaskById(id);
        await command.ExecuteAsync();
    }

    public async Task ExecuteUpdateStatusCommandAsync()
    {
        var id = ReadValue<int>("Write id", "Invalid id", int.TryParse);
        var status = ReadValue<bool>("Write new status", "Invalid status", bool.TryParse);
        
        var command = _commandFactory.CreateUpdateTaskStatus(id, status);
        await command.ExecuteAsync();
    }

    public async Task ExecuteDeleteCommandAsync()
    {
        var id = ReadValue<int>("Write id", "Invalid id", int.TryParse);
        
        var command = _commandFactory.CreateDeleteTask(id);
        await command.ExecuteAsync();
    }
    
    private T ReadValue<T>( string tip, string errorText, TryParseDelegate<T> tryParse)
    {
        Console.WriteLine(tip);
        while (true)
        {
            if (!tryParse(Console.ReadLine(), out var result))
            {
                Console.WriteLine(errorText);
            }
            else
            {
                return result;
            }
        }
    }

    private delegate bool TryParseDelegate<T>(string input, out T result);
}