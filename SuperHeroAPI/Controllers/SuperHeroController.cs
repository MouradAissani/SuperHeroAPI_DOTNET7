namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes() => Ok(await _superHeroService.GetAllSuperHeroes());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = await _superHeroService.GetSingleSuperHero(id);
            if (hero is null)
            {
                return NotFound("Sorry, but this hero doesn't exist.");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            var results = await _superHeroService.AddSuperHeroes(hero);
            return Ok(results);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(int id, SuperHero request)
        {
            var results = await _superHeroService.UpdateSuperHeroes(id, request);
            if (results is null)
            {
                return NotFound("Sorry, but this hero doesn't exist.");
            }
            return Ok(results);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        {
            var result = await _superHeroService.DeleteSuperHeroes(id);
            if (result is null)
                return NotFound("Hero not found");
            return Ok(result);
        }
    }
}
