using MyHeroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyHeroes.Repository.Interface
{
    public interface IHeroRepository : IDisposable
    {
        IEnumerable<Hero> GetAllHeroes();
        Hero GetHeroById(int heroId);
        int AddHero(Hero hero);
        int Updatehero(Hero hero);
        void DeleteHero(int heroId);
    }
}
