using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyHeroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHeroes.Map
{
    public class LeagueOfHeroesMap
    {
        public LeagueOfHeroesMap(EntityTypeBuilder<LeagueOfHeroes> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Codigo);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.HasMany(t => t.Heroes);
        }
    }
}
