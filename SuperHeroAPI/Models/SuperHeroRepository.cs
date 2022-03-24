using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperHeroAPI.Models
{
    public class SuperHeroRepository : ISuperHeroRepository
    {
        private readonly SuperHeroDbContext _context;

        public SuperHeroRepository(SuperHeroDbContext context)
        {
            _context = context;
        }

        public async Task<SuperHero> Create(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return hero;
        }

        public async Task Delete(int id)
        {
            var heroToRemove = _context.SuperHeroes.Find(id);
            _context.SuperHeroes.Remove(heroToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SuperHero>> Get()
        {
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<SuperHero> Get(int id)
        {
            return await _context.SuperHeroes.FirstAsync(h => h.Id == id);
        }

        public async Task Update(SuperHero hero)
        {
            _context.Entry(hero).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}