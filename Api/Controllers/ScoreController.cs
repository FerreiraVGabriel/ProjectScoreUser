using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreService _scoreService;

        public ScoreController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        [HttpGet]
        public IActionResult Calcular([FromQuery] decimal rendimentoAnual, [FromQuery] int idade)
        {
            int score = _scoreService.CalcularScore(rendimentoAnual, idade);
            return Ok(score); 
        }
    }
}
