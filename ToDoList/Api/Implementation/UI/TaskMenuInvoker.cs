using Api.Abstractions;

namespace Api.Implementation.UI;

public class TaskMenuInvoker : ITaskMenuInvoker
{
    private readonly Dictionary<string, ICommand> _commands;

    public TaskMenuInvoker(Dictionary<string, ICommand> commands)
    {
        _commands = commands;
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\nКоманды: add, delete, show, exit");
            Console.Write("Введите команду: ");
            string input = Console.ReadLine()!;

            if (input == "exit") break;

            if (_commands.TryGetValue(input, out var command))
                command.Execute();
            else
                Console.WriteLine("Неизвестная команда");           
        }
    }
}