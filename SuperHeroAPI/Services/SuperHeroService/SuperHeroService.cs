namespace SuperHeroAPI.Services.SuperHeroService;

public class SuperHeroService : ISuperHeroService
{
    private readonly DataDbContext _context;


    public SuperHeroService(DataDbContext context)
    {
        _context = context;
    }
    public Task<List<SuperHero>> GetAllSuperHeroes() => _context.SuperHeroes.ToListAsync();

    public async Task<SuperHero> GetSingleSuperHero(int id)
    {
        var hero = await _context.SuperHeroes.FirstOrDefaultAsync(s => s.Id == id);
        if (hero is null)
        {
            return null;
        }
        return hero;
    }

    public async Task<List<SuperHero>> AddSuperHeroes(SuperHero hero)
    {
        await _context.SuperHeroes.AddAsync(hero);
        _context.Entry(hero).State = EntityState.Added;
        await _context.SaveChangesAsync();
        return await GetAllSuperHeroes();
    }

    public async Task<List<SuperHero>> UpdateSuperHeroes(int id, SuperHero superHero)
    {
        var hero = await GetSingleSuperHero(id);
        if (hero is null)
        {
            return null;
        }

        hero.Name = superHero.Name;
        hero.Firstname = superHero.Firstname;
        hero.Lastname = superHero.Lastname;
        hero.Location = superHero.Location;
        _context.Entry(hero).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return await GetAllSuperHeroes();
    }

    public async Task<List<SuperHero>> DeleteSuperHeroes(int id)
    {
        var hero = await GetSingleSuperHero(id);
        if (hero is null)
        {
            return null;
        }

        _context.Entry(hero).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return await GetAllSuperHeroes();
    }
}