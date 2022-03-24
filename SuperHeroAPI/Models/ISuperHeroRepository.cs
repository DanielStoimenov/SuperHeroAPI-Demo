using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperHeroAPI.Models
{
    public interface ISuperHeroRepository
    {
        Task<IEnumerable<SuperHero>> Get();

        Task<SuperHero> Get(int id);

        Task<SuperHero> Create(SuperHero hero);

        Task Update(SuperHero hero);

        Task Delete(int id);
    }
}