using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHeroes.Models
{
    public class LeagueOfHeroes
    {
        public int Codigo { get; set; }
        public string Name { get; set; }
        public List<Hero> Heroes{ get; set; }
    }
}
