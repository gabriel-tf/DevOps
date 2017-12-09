using Microsoft.EntityFrameworkCore;
using MyHeroes.Models;
using MyHeroes.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyHeroes.Repository
{
    public class HeroRepository : IHeroRepository
    {
        private readonly HeroesContext _context;

        public HeroRepository(HeroesContext context)
        {
            _context = context;
        }

        public IEnumerable<Hero> GetAllHeroes()
        {
            return _context.Hero.ToList();
        }

        public Hero GetHeroById(int heroId)
        {
            return _context.Hero.Find(heroId);
        }

        public int AddHero(Hero hero)
        {
            int result = -1;

            if (hero != null)
            {
                _context.Hero.Add(hero);
                _context.SaveChanges();
                result = hero.Id;
            }
            return result;
        }

        public int Updatehero(Hero hero)
        {
            int result = -1;

            if (hero != null)
            {
                _context.Entry(hero).State = EntityState.Modified;
                _context.SaveChanges();
                result = hero.Id;
            }
            return result;
        }

        public void DeleteHero(int heroId)
        {
            Hero hero = _context.Hero.Find(heroId);
            _context.Hero.Remove(hero);
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

    }
}
