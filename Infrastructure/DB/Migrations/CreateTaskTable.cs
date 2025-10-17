using FluentMigrator;
using FluentMigrator.SqlServer;

namespace Infrastructure.DB.Migrations;

[Migration(2)]
public class CreateTaskTable : Migration
{
    public override void Up()
    {
        Create.Table("Tasks")
            .WithColumn("Id").AsInt32().Identity().PrimaryKey()
            .WithColumn("Title").AsString()
            .WithColumn("Description").AsString()
            .WithColumn("IsCompleted").AsBoolean()
            .WithColumn("CreatedAt").AsDateTime();
    }

    public override void Down()
    {
        Delete.Table("Task");
    }
}