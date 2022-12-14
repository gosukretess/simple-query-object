using System.Data;

namespace QueryObjectPatternExamples.Database.Dapper.Infrastructure;

public interface IDbQuery<TResult>
{
    Task<TResult> ExecuteAsync(IDbConnection connection, IDbTransaction transaction, CancellationToken cancellationToken);
}