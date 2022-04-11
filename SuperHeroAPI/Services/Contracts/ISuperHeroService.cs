using SuperHeroAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperHeroAPI.Services.Contracts
{
    public interface ISuperHeroService
    {
        Task<IEnumerable<SuperHero>> Get();

        Task<SuperHero> GetById(int id);

        Task<SuperHero> AddHero(SuperHero hero);

        Task UpdateHero(int id, SuperHero hero);

        Task DeleteHero(int id);
    }
}