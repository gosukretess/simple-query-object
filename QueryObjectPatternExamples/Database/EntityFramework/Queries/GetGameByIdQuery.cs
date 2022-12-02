using Microsoft.EntityFrameworkCore;
using QueryObjectPatternExamples.Database.EntityFramework.Infrastructure;

namespace QueryObjectPatternExamples.Database.EntityFramework.Queries;

public class GetGameByIdQuery : IEfDbQuery<GameDbo>
{
    public int GameId { get; init; }

    public GetGameByIdQuery(int gameId)
    {
        GameId = gameId;
    }

    public async Task<GameDbo> ExecuteAsync(DbContext context, CancellationToken cancellationToken)
    {
        var gameRecord = await context.Set<GameDbo>().FirstOrDefaultAsync(q => q.Id == GameId, cancellationToken);

        if (gameRecord == null)
        {
            throw new RecordNotFoundException();
        }

        return gameRecord;
    }
}