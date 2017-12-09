using MyHeroes.Models;
using MyHeroes.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHeroes.Repository
{
    public class HeroRepository : BaseRepository<Hero>, IHeroRepository
    {
        IUnitOfWork unitOfWork = new HeroesContext();

        public HeroRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
