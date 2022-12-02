using MediatR;
using QueryObjectPatternExamples.Database.EntityFramework.Infrastructure;
using QueryObjectPatternExamples.Database.EntityFramework.Queries;

namespace QueryObjectPatternExamples.GamesEF.GetGame;

public class GetGameHandler : IRequestHandler<GetGameEfQuery, Game>
{
    private readonly IEfQueryExecutor _queryExecutor;

    public GetGameHandler(IEfQueryExecutor queryExecutor)
    {
        _queryExecutor = queryExecutor;
    }

    public async Task<Game> Handle(GetGameEfQuery request, CancellationToken cancellationToken)
    {
        var query = new GetGameByIdQuery(request.Id);
        var result = await _queryExecutor.ExecuteAsync(query, cancellationToken);

        return new Game
        {
            Id = result.Id,
            Name = result.Name
        };
    }
}