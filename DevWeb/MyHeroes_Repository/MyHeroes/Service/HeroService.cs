using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyHeroes.Models;
using MyHeroes.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHeroes.Service
{
    public class HeroService : BaseService<Hero>, IHeroService
    {
        private ModelStateDictionary _modelState;

        public HeroService(ModelStateDictionary modelState)
        {
            _modelState = modelState;
        }

        public bool Validate(Hero item)
        {
            if (item.Id == 0)
            {
                if (this.List().Where(c => c.Name == item.Name).Count() > 0)
                    _modelState.AddModelError("Name", "Herói já cadastrado");
            }

            return _modelState.IsValid;
        }
    }
}
