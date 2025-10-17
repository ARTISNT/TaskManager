using System.Globalization;
using Application.Abstractions;
using Application.Services;
using Domain.Models.Entities;

namespace Api;

public class Ui
{
    private readonly ITaskService _taskService;

    public Ui(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    public async Task Run()
    {
        while (true)
        {
            Console.WriteLine("Choose an action:\n" +
                              "1.Add task\n" +
                              "2.Get all tasks\n" +
                              "3.Get task by id\n" +
                              "4.Update status of task\n" +
                              "5.Delete task\n" +
                              "6.Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Description:\n");
                    string description = Console.ReadLine();
                    
                    Console.WriteLine("Title:\n");
                    string title = Console.ReadLine();

                    TaskEntity task = new TaskEntity()
                    {
                        Description = description,
                        Title = title,
                    };
                    
                    await _taskService.Create(task);
                    Console.WriteLine("Task added successfully");
                    break;
                
                case "2":
                    var tasks = await _taskService.GetAll();

                    foreach (var taskF in tasks)
                    {
                        Console.WriteLine(taskF.Description);
                        Console.WriteLine(taskF.Title);
                        Console.WriteLine(taskF.Id);
                        Console.WriteLine(taskF.CreatedAt);
                        Console.WriteLine(taskF.IsCompleted);
                    }
                    break;
                
                case "3":
                    int id = int.Parse(Console.ReadLine());
                    var taskInput = await _taskService.GetById(id);
                    
                    Console.WriteLine(taskInput.Description);
                    Console.WriteLine(taskInput.Title);
                    Console.WriteLine(taskInput.Id);
                    Console.WriteLine(taskInput.CreatedAt);
                    Console.WriteLine(taskInput.IsCompleted);
                    break;
                
                case "4":
                    int id4 = int.Parse(Console.ReadLine());
                    bool newStatus = bool.Parse(Console.ReadLine());
                    
                    await _taskService.UpdateStatus(id4, newStatus);
                    Console.WriteLine("Task updated successfully");
                    break;
                
                case "5":
                    int idDelete = int.Parse(Console.ReadLine());
                    await _taskService.Delete(idDelete);
                    Console.WriteLine("Task deleted successfully");
                    break;
                
                case "6":
                    return;
            }
        }
    }
}