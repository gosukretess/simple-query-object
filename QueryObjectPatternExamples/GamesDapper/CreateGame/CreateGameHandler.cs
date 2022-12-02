using MediatR;
using QueryObjectPatternExamples.Database.Dapper.Infrastructure;
using QueryObjectPatternExamples.Database.Dapper.Queries;

namespace QueryObjectPatternExamples.GamesDapper.CreateGame;

public class CreateGameHandler : IRequestHandler<CreateGameQuery, bool>
{
    private readonly IQueryExecutor _queryExecutor;

    public CreateGameHandler(IQueryExecutor queryExecutor)
    {
        _queryExecutor = queryExecutor;
    }


    public async Task<bool> Handle(CreateGameQuery request, CancellationToken cancellationToken)
    {
        var query = new AddGameQuery(request.Name);
        return await _queryExecutor.ExecuteAsync(query, cancellationToken);
    }
}