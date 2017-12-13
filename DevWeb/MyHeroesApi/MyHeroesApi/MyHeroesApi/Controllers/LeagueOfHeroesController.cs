using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHeroesApi;
using MyHeroesApi.Models;

namespace MyHeroesApi.Controllers
{
    [Produces("application/json")]
    [Route("api/LeagueOfHeroes")]
    public class LeagueOfHeroesController : Controller
    {
        private readonly HeroesContext _context;

        public LeagueOfHeroesController(HeroesContext context)
        {
            _context = context;
        }

        // GET: api/LeagueOfHeroes
        [HttpGet]
        public IEnumerable<LeagueOfHeroes> GetLeagueOfHeroes()
        {
            return _context.LeagueOfHeroes;
        }

        // GET: api/LeagueOfHeroes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeagueOfHeroes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var leagueOfHeroes = await _context.LeagueOfHeroes.SingleOrDefaultAsync(m => m.Id == id);

            if (leagueOfHeroes == null)
            {
                return NotFound();
            }

            return Ok(leagueOfHeroes);
        }

        // PUT: api/LeagueOfHeroes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeagueOfHeroes([FromRoute] int id, [FromBody] LeagueOfHeroes leagueOfHeroes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leagueOfHeroes.Id)
            {
                return BadRequest();
            }

            _context.Entry(leagueOfHeroes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeagueOfHeroesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LeagueOfHeroes
        [HttpPost]
        public async Task<IActionResult> PostLeagueOfHeroes([FromBody] LeagueOfHeroes leagueOfHeroes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LeagueOfHeroes.Add(leagueOfHeroes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeagueOfHeroes", new { id = leagueOfHeroes.Id }, leagueOfHeroes);
        }

        // DELETE: api/LeagueOfHeroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeagueOfHeroes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var leagueOfHeroes = await _context.LeagueOfHeroes.SingleOrDefaultAsync(m => m.Id == id);
            if (leagueOfHeroes == null)
            {
                return NotFound();
            }

            _context.LeagueOfHeroes.Remove(leagueOfHeroes);
            await _context.SaveChangesAsync();

            return Ok(leagueOfHeroes);
        }

        private bool LeagueOfHeroesExists(int id)
        {
            return _context.LeagueOfHeroes.Any(e => e.Id == id);
        }
    }
}