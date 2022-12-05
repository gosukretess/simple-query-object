using System.Collections.ObjectModel;
using System.Data;
using Dapper;
using Microsoft.IdentityModel.Tokens;
using QueryObjectPatternExamples.Database.Dapper.Infrastructure;
using QueryObjectPatternExamples.GamesDapper.GetGame;

namespace QueryObjectPatternExamples.Database.Dapper.Queries;

public class GetAllGamesQuery : IDbQuery<IReadOnlyCollection<Game>>
{
    public async Task<IReadOnlyCollection<Game>> ExecuteAsync(IDbConnection connection, IDbTransaction transaction, CancellationToken cancellationToken)
    {
        const string sql = $@"
        SELECT 
        [Id] AS [{nameof(Game.Id)}],
        [Name] AS [{nameof(Game.Name)}]
        FROM [Games]";

        var command = new CommandDefinition(
            commandText: sql,
            parameters: this,
            transaction: transaction,
            cancellationToken: cancellationToken
        );
        var gameRecords = await connection.QueryAsync<Game>(command);
        if (gameRecords.IsNullOrEmpty())
        {
            throw new RecordNotFoundException();
        }

        return new ReadOnlyCollection<Game>(gameRecords.ToList());
    }
}