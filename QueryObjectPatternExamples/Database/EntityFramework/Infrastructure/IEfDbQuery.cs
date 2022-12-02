using Microsoft.EntityFrameworkCore;

namespace QueryObjectPatternExamples.Database.EntityFramework.Infrastructure;

public interface IEfDbQuery<TResult>
{
    Task<TResult> ExecuteAsync(DbContext connection, CancellationToken cancellationToken);
}