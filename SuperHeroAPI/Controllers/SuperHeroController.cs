using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using SuperHeroAPI.Services.Contracts;

namespace SuperHeroAPI.Controllers
{
    /// <summary>
    /// Controller for managing Superheroes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _heroService;

        /// <summary>
        /// Default constructor for controller
        /// </summary>
        /// <param name="heroService"></param>
        public SuperHeroController(ISuperHeroService heroService)
        {
            _heroService = heroService;
        }

        /// <summary>
        /// Endpoint for getting all heroes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<SuperHero>> Get()
        {
            return await _heroService.Get();
        }

        /// <summary>
        /// Endpoint for getting heroe by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var heroe = await _heroService.GetById(id);

            if (heroe == null)
            {
                return NotFound();
            }

            return heroe;
        }

        /// <summary>
        /// Endpoint for adding new heroe
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<SuperHero>> AddHero([FromBody] SuperHero hero)
        {
            var newSuperHero = await _heroService.AddHero(hero);
            return CreatedAtAction(nameof(Get), new { Id = newSuperHero.Id }, newSuperHero);
        }

        /// <summary>
        /// Endpoint for update hero
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hero"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Endpoint for delete heroe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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