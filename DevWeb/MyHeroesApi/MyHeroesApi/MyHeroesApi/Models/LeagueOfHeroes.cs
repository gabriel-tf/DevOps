using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHeroesApi.Models
{
    public class LeagueOfHeroes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Hero> Heroes { get; set; }

        public LeagueOfHeroes()
        {
            Heroes = new List<Hero>();
        }
    }
}
