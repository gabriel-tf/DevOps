using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyHeroesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHeroesApi.Map
{
    public class HeroMap
    {
        public HeroMap(EntityTypeBuilder<Hero> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.Power).IsRequired();
        }
    }
}
