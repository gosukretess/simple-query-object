using MediatR;

namespace QueryObjectPatternExamples.GamesDapper.CreateGame;

public class CreateGameQuery : IRequest<bool>
{
    public string Name { get; set; }
}