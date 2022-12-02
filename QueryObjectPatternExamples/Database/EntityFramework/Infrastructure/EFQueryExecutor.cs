using Microsoft.EntityFrameworkCore;

namespace QueryObjectPatternExamples.Database.EntityFramework.Infrastructure;

public class EfQueryExecutor<T> : IEfQueryExecutor where T : DbContext
{
    private readonly DbContext _context;

    public EfQueryExecutor(T context)
    {
        _context = context;
    }

    public async Task<TResult> ExecuteAsync<TResult>(IEfDbQuery<TResult> query, CancellationToken cancellationToken)
    {
        return await query.ExecuteAsync(_context, cancellationToken);
    }
}