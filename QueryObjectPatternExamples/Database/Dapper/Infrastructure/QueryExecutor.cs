using System.Data;
using Microsoft.Data.SqlClient;

namespace QueryObjectPatternExamples.Database.Dapper.Infrastructure;

public interface IQueryExecutor
{
    public Task<TResult> ExecuteAsync<TResult>(IDbQuery<TResult> query, CancellationToken cancellationToken);
}

public class QueryExecutor : IQueryExecutor
{
    private readonly IConfiguration _configuration;

    public QueryExecutor(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // Very simple executor, just creating connection and executing query on database
    public async Task<TResult> ExecuteAsync<TResult>(IDbQuery<TResult> query, CancellationToken cancellationToken)
    {
        var connectionString = _configuration.GetValue<string>("ConnectionString");
        using IDbConnection connection = new SqlConnection(connectionString);
        return await query.ExecuteAsync(connection, cancellationToken);
    }
}