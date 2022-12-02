using MediatR;
using QueryObjectPatternExamples.Database.EntityFramework.Infrastructure;
using QueryObjectPatternExamples.Database.EntityFramework.Queries;

namespace QueryObjectPatternExamples.GamesEF.CreateGame;

public class CreateGameHandler : IRequestHandler<CreateGameEfQuery, bool>
{
    private readonly IEfQueryExecutor _queryExecutor;

    public CreateGameHandler(IEfQueryExecutor queryExecutor)
    {
        _queryExecutor = queryExecutor;
    }


    public async Task<bool> Handle(CreateGameEfQuery request, CancellationToken cancellationToken)
    {
        var query = new AddGameQuery(request.Name);
        return await _queryExecutor.ExecuteAsync(query, cancellationToken);
    }
}