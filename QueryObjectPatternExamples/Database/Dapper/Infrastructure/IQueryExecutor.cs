namespace QueryObjectPatternExamples.Database.Dapper.Infrastructure;

public interface IQueryExecutor
{
    Task<TResult> ExecuteAsync<TResult>(IDbQuery<TResult> query, CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
}