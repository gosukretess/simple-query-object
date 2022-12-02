namespace QueryObjectPatternExamples.Database.EntityFramework.Infrastructure;

public interface IEfQueryExecutor
{
    public Task<TResult> ExecuteAsync<TResult>(IEfDbQuery<TResult> query, CancellationToken cancellationToken);
}