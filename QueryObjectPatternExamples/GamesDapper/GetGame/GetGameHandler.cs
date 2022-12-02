using MediatR;
using QueryObjectPatternExamples.Database.Dapper.Infrastructure;
using QueryObjectPatternExamples.Database.Dapper.Queries;

namespace QueryObjectPatternExamples.GamesDapper.GetGame;

public class GetGameHandler : IRequestHandler<GetGameQuery, Game>
{
    private readonly IQueryExecutor _queryExecutor;

    public GetGameHandler(IQueryExecutor queryExecutor)
    {
        _queryExecutor = queryExecutor;
    }

    public async Task<Game> Handle(GetGameQuery request, CancellationToken cancellationToken)
    {
        var query = new GetGameByIdQuery(request.Id);
        return await _queryExecutor.ExecuteAsync(query, cancellationToken);
    }
}