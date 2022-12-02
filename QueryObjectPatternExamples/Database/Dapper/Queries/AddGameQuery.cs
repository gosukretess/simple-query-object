using System.Data;
using Dapper;
using QueryObjectPatternExamples.Database.Dapper.Infrastructure;

namespace QueryObjectPatternExamples.Database.Dapper.Queries;

public class AddGameQuery : IDbQuery<bool>
{
    public string Name { get; set; }

    public AddGameQuery(string name)
    {
        Name = name;
    }

    public async Task<bool> ExecuteAsync(IDbConnection connection, CancellationToken cancellationToken)
    {
        const string sql = $@"
INSERT INTO [Games]
           ([Name])
     VALUES
           (@{nameof(Name)})

SELECT @@ROWCOUNT;
";

        var command = new CommandDefinition(
            commandText: sql,
            parameters: this,
            cancellationToken: cancellationToken
        );
        var success = await connection.ExecuteScalarAsync<bool>(command);

        return success;
    }
}