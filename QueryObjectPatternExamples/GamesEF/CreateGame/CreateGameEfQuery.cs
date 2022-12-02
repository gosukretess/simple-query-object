using MediatR;

namespace QueryObjectPatternExamples.GamesEF.CreateGame;

public class CreateGameEfQuery : IRequest<bool>
{
    public string Name { get; set; }
}