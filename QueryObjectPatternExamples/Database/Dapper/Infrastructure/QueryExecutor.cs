namespace QueryObjectPatternExamples.Database.Dapper.Infrastructure;

public class QueryExecutor : IQueryExecutor
{
    private readonly IDbContext _dbContext;

    public QueryExecutor(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TResult> ExecuteAsync<TResult>(IDbQuery<TResult> query, CancellationToken cancellationToken)
    {
        var connection = await _dbContext.GetDbConnectionAsync(cancellationToken);
        var transaction = await _dbContext.GetTransactionAsync(cancellationToken);
        return await query.ExecuteAsync(connection, transaction, cancellationToken);
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await _dbContext.CommitAsync(cancellationToken);
    }
}