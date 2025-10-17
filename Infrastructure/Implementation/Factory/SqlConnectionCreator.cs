using System.Data.Common;
using Infrastructure.Abstractions.Factory;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Implementation.Factory;

public class SqlConnectionCreator : ICreatorOfConnection
{
    private readonly string _connectionString;

    public SqlConnectionCreator(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
    
    public string GetConnectionString()
    {
        return _connectionString;
    }
}