using Api.Abstractions;

namespace Api.Implementation.UI;

public class TaskMenuInvoker : ITaskMenuInvoker
{
    private readonly ICommandsHandling _commandsHandling;

    public TaskMenuInvoker(ICommandsHandling commandsHandling)
    {
        _commandsHandling = commandsHandling;
    }

    public async Task Run()
    {
        while (true)
        {
            try
            {
                await ManageMenuChoice();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong.");
            }
        }
    }

    private async Task ManageMenuChoice()
    {
        Console.WriteLine("\nChoose an action:\n" +
                          "1.Add task\n" +
                          "2.Get all tasks\n" +
                          "3.Get task by id\n" +
                          "4.Update status of task\n" +
                          "5.Delete task\n" +
                          "6.Exit\n");

        if(!int.TryParse(Console.ReadLine(), out var choice))
        {
            Console.WriteLine("Invalid number of choice.");
        }

        switch (choice)
        {
            case 1:
                await _commandsHandling.ExecuteAddCommandAsync();
                break;
            case 2:
                await _commandsHandling.ExecuteGetAllCommandsAsync();
                break;
            case 3:
                await _commandsHandling.ExecuteGetTaskByIdAsync();
                break;
            case 4:
                await _commandsHandling.ExecuteUpdateStatusCommandAsync();
                break;
            case 5:
                await _commandsHandling.ExecuteDeleteCommandAsync();
                break;
            case 6:
                Console.WriteLine("Goodbye(");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
}