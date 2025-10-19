using System.Data;
using Api;
using Api.Abstractions;
using Api.Implementation.Factories;
using Api.Implementation.Managers;
using Api.Implementation.UI;
using Application.Abstractions;
using Application.Services;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Infrastructure.Abstractions.Factory;
using Infrastructure.Abstractions.Repositories;
using Infrastructure.DB.Migrations;
using Infrastructure.Implementation.Factory;
using Infrastructure.Implementation.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var connectionString = config.GetConnectionString("DefaultConnection");

var services = new ServiceCollection();

services.AddTransient<ICreatorOfConnection, SqlConnectionCreator>(sp =>
{
    if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
    return new SqlConnectionCreator(connectionString);
});
services.AddTransient<ITaskRepository, TaskRepository>();
services.AddTransient<ITaskService, TaskService>();
services.AddTransient<ICommandFactory, CommandFactory>();
services.AddTransient<ITaskManager, TaskManager>();
services.AddTransient<ICommandsHandling, CommandsHandling>();
services.AddTransient<ITaskMenuInvoker,  TaskMenuInvoker>();

var builderServices = services.BuildServiceProvider();

var taskMenuInvoker =  builderServices.GetRequiredService<ITaskMenuInvoker>();
await taskMenuInvoker.Run();

/*
using (var serviceProvider = CreateServices())
using (var scope = serviceProvider.CreateScope())
{
    UpdateDatabase(scope.ServiceProvider);
}

ServiceProvider CreateServices()
{
    return new ServiceCollection()
        .AddFluentMigratorCore()
        .ConfigureRunner(rb => rb
            .AddSqlServer()
            .WithGlobalConnectionString(connectionString)
            .ScanIn(typeof(CreateTaskTable).Assembly).For.All())
        .AddLogging(lb => lb.AddFluentMigratorConsole())
        .BuildServiceProvider(false);
}

void UpdateDatabase(IServiceProvider serviceProvider)
{
    var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

    runner.MigrateUp();
}*/