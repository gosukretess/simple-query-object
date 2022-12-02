using MediatR;
using Microsoft.AspNetCore.Mvc;
using QueryObjectPatternExamples.GamesDapper.CreateGame;
using QueryObjectPatternExamples.GamesDapper.GetAllGames;
using QueryObjectPatternExamples.GamesDapper.GetGame;

namespace QueryObjectPatternExamples.GamesDapper
{
    [ApiController]
    [Route("api/games-dapper")]
    public class GamesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var result = await _mediator.Send(new GetAllGamesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetGameQuery { Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetGame(CreateGameQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
