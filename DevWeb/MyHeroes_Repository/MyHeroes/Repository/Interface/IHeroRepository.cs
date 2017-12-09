using MyHeroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHeroes.Repository.Interface
{
    public interface IHeroRepository : IBaseRepository<Hero>, IDisposable
    {
    }
}
