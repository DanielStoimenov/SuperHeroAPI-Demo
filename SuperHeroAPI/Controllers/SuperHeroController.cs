using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

using SuperHeroAPI.Data;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.Contracts;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _heroService;

        public SuperHeroController(ISuperHeroService heroService)
        {
            _heroService = heroService;
        }

        [HttpGet]
        public async Task<IEnumerable<SuperHero>> Get()
        {
            return await _heroService.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            return await _heroService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<SuperHero>> AddHero([FromBody] SuperHero hero)
        {
            var newSuperHero = await _heroService.AddHero(hero);
            return CreatedAtAction(nameof(Get), new { Id = newSuperHero.Id }, newSuperHero);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateHero(int id, [FromBody] SuperHero hero)
        {
            if (id != hero.Id)
            {
                return BadRequest("Hero not found");
            }
            await _heroService.UpdateHero(id, hero);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHero(int id)
        {
            var heroToRemove = await _heroService.GetById(id);
            if (heroToRemove == null)
            {
                return BadRequest("Hero not found");
            }
            await _heroService.DeleteHero(id);
            return NoContent();
        }
    }
}