using MyHeroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHeroes.Service.Interface
{
    public interface IHeroService : IBaseService<Hero>, IDisposable
    {
        bool Validate(Hero hero);
    }
}
