using System.Data.Common;

namespace QueryObjectPatternExamples.Database.Dapper.Infrastructure;

public interface IDbContext
{
    ValueTask<DbConnection> GetDbConnectionAsync(CancellationToken cancellationToken);
    ValueTask<DbTransaction> GetTransactionAsync(CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
}