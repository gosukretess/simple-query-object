using MediatR;
using QueryObjectPatternExamples.Database.Dapper.Infrastructure;
using QueryObjectPatternExamples.GamesDapper.GetGame;

namespace QueryObjectPatternExamples.GamesDapper.GetAllGames;

public class GetAllGamesHandler : IRequestHandler<GetAllGamesQuery, IReadOnlyCollection<Game>>
{
    private readonly IQueryExecutor _queryExecutor;

    public GetAllGamesHandler(IQueryExecutor queryExecutor)
    {
        _queryExecutor = queryExecutor;
    }

    public async Task<IReadOnlyCollection<Game>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
    {
        var query = new Database.Dapper.Queries.GetAllGamesQuery();
        return await _queryExecutor.ExecuteAsync(query, cancellationToken);
    }
}