using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

using SuperHeroAPI.Data;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroRepository _heroRepository;

        public SuperHeroController(ISuperHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<SuperHero>> Get()
        {
            return await _heroRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            return await _heroRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<SuperHero>> AddHero([FromBody] SuperHero hero)
        {
            var newSuperHero = await _heroRepository.Create(hero);
            return CreatedAtAction(nameof(Get), new { Id = newSuperHero.Id }, newSuperHero);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateHero(int id, [FromBody] SuperHero hero)
        {
            if (id != hero.Id)
            {
                return BadRequest("Hero not found");
            }
            await _heroRepository.Update(hero);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHero(int id)
        {
            var heroToRemove = await _heroRepository.Get(id);
            if (heroToRemove == null)
            {
                return BadRequest("Hero not found");
            }
            await _heroRepository.Delete(heroToRemove.Id);
            return NoContent();
        }
    }
}