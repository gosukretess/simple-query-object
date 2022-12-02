using MediatR;

namespace QueryObjectPatternExamples.GamesDapper.GetGame;

public class GetGameQuery : IRequest<Game>
{
    public int Id { get; set; }
}