using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyHeroes;
using MyHeroes.Models;

namespace MyHeroes.Controllers
{
    public class LeagueOfHeroesController : Controller
    {
        private readonly HeroesContext _context;

        public LeagueOfHeroesController(HeroesContext context)
        {
            _context = context;
        }

        // GET: LeagueOfHeroes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LeagueOfHeroes.ToListAsync());
        }

        // GET: LeagueOfHeroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leagueOfHeroes = await _context.LeagueOfHeroes
                .SingleOrDefaultAsync(m => m.Codigo == id);
            if (leagueOfHeroes == null)
            {
                return NotFound();
            }

            return View(leagueOfHeroes);
        }

        // GET: LeagueOfHeroes/Create
        public async Task<IActionResult> Create()
        {
            LeagueOfHeroes leagueOfHeroes = new LeagueOfHeroes();
            leagueOfHeroes.Heroes = await _context.Hero.ToListAsync();
            return View(leagueOfHeroes);
        }

        [HttpGet]
        public async Task<IActionResult> CreateLeague(string leagueName, List<int> heroes)
        {
            LeagueOfHeroes leagueOfHeroes = new LeagueOfHeroes();
            leagueOfHeroes.Name = leagueName;

            foreach (var heroId in heroes)
            {
                Hero hero = new Hero();
                hero = await _context.Hero.SingleOrDefaultAsync(m => m.Codigo == heroId);
                leagueOfHeroes.Heroes.Add(hero);
            }

            if (ModelState.IsValid)
            {
                _context.Add(leagueOfHeroes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(leagueOfHeroes);
        }

        // POST: LeagueOfHeroes/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Codigo,Name")] LeagueOfHeroes leagueOfHeroes)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(leagueOfHeroes);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(leagueOfHeroes);
        //}

        // GET: LeagueOfHeroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leagueOfHeroes = await _context.LeagueOfHeroes.SingleOrDefaultAsync(m => m.Codigo == id);
            if (leagueOfHeroes == null)
            {
                return NotFound();
            }
            return View(leagueOfHeroes);
        }

        // POST: LeagueOfHeroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,Name")] LeagueOfHeroes leagueOfHeroes)
        {
            if (id != leagueOfHeroes.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leagueOfHeroes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeagueOfHeroesExists(leagueOfHeroes.Codigo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leagueOfHeroes);
        }

        // GET: LeagueOfHeroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leagueOfHeroes = await _context.LeagueOfHeroes
                .SingleOrDefaultAsync(m => m.Codigo == id);
            if (leagueOfHeroes == null)
            {
                return NotFound();
            }

            return View(leagueOfHeroes);
        }

        // POST: LeagueOfHeroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leagueOfHeroes = await _context.LeagueOfHeroes.SingleOrDefaultAsync(m => m.Codigo == id);
            _context.LeagueOfHeroes.Remove(leagueOfHeroes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeagueOfHeroesExists(int id)
        {
            return _context.LeagueOfHeroes.Any(e => e.Codigo == id);
        }
    }
}
