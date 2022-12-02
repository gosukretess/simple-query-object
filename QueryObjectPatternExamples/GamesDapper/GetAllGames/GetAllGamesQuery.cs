using MediatR;
using QueryObjectPatternExamples.GamesDapper.GetGame;

namespace QueryObjectPatternExamples.GamesDapper.GetAllGames;

public class GetAllGamesQuery : IRequest<IReadOnlyCollection<Game>>
{

}