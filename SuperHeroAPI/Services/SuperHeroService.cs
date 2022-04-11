using SuperHeroAPI.Models;
using SuperHeroAPI.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperHeroAPI.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly ISuperHeroRepository _heroRepository;

        public SuperHeroService(ISuperHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        public async Task<SuperHero> AddHero(SuperHero hero)
        {
            return await _heroRepository.Create(hero);
        }

        public async Task DeleteHero(int id)
        {
            var heroToRemove = await _heroRepository.Get(id);
            await _heroRepository.Delete(id);
        }

        public async Task<IEnumerable<SuperHero>> Get()
        {
            return await _heroRepository.Get();
        }

        public async Task<SuperHero> GetById(int id)
        {
            return await _heroRepository.Get(id);
        }

        public async Task UpdateHero(int id, SuperHero hero)
        {
            await _heroRepository.Update(hero);
        }
    }
}