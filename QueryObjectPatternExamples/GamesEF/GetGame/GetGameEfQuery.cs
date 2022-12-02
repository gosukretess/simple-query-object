using MediatR;

namespace QueryObjectPatternExamples.GamesEF.GetGame;

public class GetGameEfQuery : IRequest<Game>
{
    public int Id { get; set; }
}