using MediatR;
using Microsoft.AspNetCore.Mvc;
using QueryObjectPatternExamples.GamesEF.CreateGame;
using QueryObjectPatternExamples.GamesEF.GetAllGames;
using QueryObjectPatternExamples.GamesEF.GetGame;

namespace QueryObjectPatternExamples.GamesEF
{
    [ApiController]
    [Route("api/games-ef")]
    public class GamesEfController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GamesEfController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var result = await _mediator.Send(new GetAllGamesEfQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetGameEfQuery { Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetGame(CreateGameEfQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
