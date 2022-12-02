using System.Data;
using Dapper;
using QueryObjectPatternExamples.Database.Dapper.Infrastructure;
using QueryObjectPatternExamples.GamesDapper.GetGame;

namespace QueryObjectPatternExamples.Database.Dapper.Queries;

public class GetGameByIdQuery : IDbQuery<Game>
{
    public int GameId { get; init; }

    public GetGameByIdQuery(int gameId)
    {
        GameId = gameId;
    }

    public async Task<Game> ExecuteAsync(IDbConnection connection, CancellationToken cancellationToken)
    {
        const string sql = $@"
        SELECT TOP (1)
        [Id] AS [{nameof(Game.Id)}],
        [Name] AS [{nameof(Game.Name)}]
        FROM [Games]
        WHERE [Id] = @{nameof(GameId)}";

        var command = new CommandDefinition(
            commandText: sql,
            parameters: this,
            cancellationToken: cancellationToken
        );
        var gameRecord = await connection.QueryFirstOrDefaultAsync<Game?>(command);
        if (gameRecord == null)
        {
            throw new RecordNotFoundException();
        }
        return gameRecord;
    }
}