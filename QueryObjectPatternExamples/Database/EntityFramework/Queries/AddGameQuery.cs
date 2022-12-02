using Microsoft.EntityFrameworkCore;
using QueryObjectPatternExamples.Database.EntityFramework.Infrastructure;

namespace QueryObjectPatternExamples.Database.EntityFramework.Queries;

public class AddGameQuery : IEfDbQuery<bool>
{
    public AddGameQuery(string name)
    {
        Name = name;
    }

    public string Name { get; init; }


    public async Task<bool> ExecuteAsync(DbContext context, CancellationToken cancellationToken)
    {
        var gameRecord = await context.AddAsync(new GameDbo
        {
            Name = Name
        }, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        if (gameRecord == null)
        {
            throw new RecordNotFoundException();
        }

        // TODO: check if added
        return true;
    }
}