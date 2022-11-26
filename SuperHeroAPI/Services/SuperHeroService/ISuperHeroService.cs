namespace SuperHeroAPI.Services.SuperHeroService;

public interface ISuperHeroService
{
    Task<List<SuperHero>> GetAllSuperHeroes();
    Task<SuperHero> GetSingleSuperHero(int id);
    Task<List<SuperHero>> AddSuperHeroes(SuperHero hero);
    Task<List<SuperHero>> UpdateSuperHeroes(int id, SuperHero hero);
    Task<List<SuperHero>> DeleteSuperHeroes(int id);

}