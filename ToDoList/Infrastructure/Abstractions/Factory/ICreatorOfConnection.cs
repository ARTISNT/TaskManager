using System.Data.Common;

namespace Infrastructure.Abstractions.Factory;

public interface ICreatorOfConnection
{
    public string GetConnectionString();
    public DbConnection CreateConnection();
}