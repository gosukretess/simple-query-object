using MediatR;
using QueryObjectPatternExamples.Database.EntityFramework.Infrastructure;
using QueryObjectPatternExamples.GamesEF.GetGame;

namespace QueryObjectPatternExamples.GamesEF.GetAllGames;

public class GetAllGamesHandler : IRequestHandler<GetAllGamesEfQuery, IReadOnlyCollection<Game>>
{
    private readonly IEfQueryExecutor _queryExecutor;

    public GetAllGamesHandler(IEfQueryExecutor queryExecutor)
    {
        _queryExecutor = queryExecutor;
    }

    public async Task<IReadOnlyCollection<Game>> Handle(GetAllGamesEfQuery request, CancellationToken cancellationToken)
    {
        var query = new Database.EntityFramework.Queries.GetAllGamesQuery();
        var result = await _queryExecutor.ExecuteAsync(query, cancellationToken);

        return result.Select(q => new Game {Id = q.Id, Name = q.Name}).ToList();
    }
}