using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QueryObjectPatternExamples.Database.EntityFramework.Infrastructure;

namespace QueryObjectPatternExamples.Database.EntityFramework.Queries;

public class GetAllGamesQuery : IEfDbQuery<IReadOnlyCollection<GameDbo>>
{
    public async Task<IReadOnlyCollection<GameDbo>> ExecuteAsync(DbContext context, CancellationToken cancellationToken)
    {
        var gameRecords = await context.Set<GameDbo>().ToListAsync(cancellationToken);

        if (gameRecords.IsNullOrEmpty())
        {
            throw new RecordNotFoundException();
        }

        return new ReadOnlyCollection<GameDbo>(gameRecords);
    }
}