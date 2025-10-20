using Api.Implementation.Commands;
using Domain.Models.Entities;

namespace Api.Abstractions;

public interface ICommandFactory
{
    AddTask CreateAddTask(TaskEntity task);
    DeleteTask CreateDeleteTask(int id);
    GetAllTasks CreateGetAllTasks();
    GetTaskById CreateGetTaskById(int id);
    UpdateTaskStatus CreateUpdateTaskStatus(int id, bool status);
}