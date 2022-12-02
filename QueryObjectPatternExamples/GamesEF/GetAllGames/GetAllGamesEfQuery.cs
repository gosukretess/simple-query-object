using MediatR;
using QueryObjectPatternExamples.GamesEF.GetGame;

namespace QueryObjectPatternExamples.GamesEF.GetAllGames;

public class GetAllGamesEfQuery : IRequest<IReadOnlyCollection<Game>>
{

}