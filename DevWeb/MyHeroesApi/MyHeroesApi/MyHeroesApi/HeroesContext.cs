using Microsoft.EntityFrameworkCore;
using MyHeroesApi.Map;
using MyHeroesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHeroesApi
{
    public class HeroesContext : DbContext
    {
        public HeroesContext(DbContextOptions<HeroesContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new HeroMap(modelBuilder.Entity<Hero>());
            new LeagueOfHeroesMap(modelBuilder.Entity<LeagueOfHeroes>());
        }

        public DbSet<Hero> Hero { get; set; }
        public DbSet<LeagueOfHeroes> LeagueOfHeroes { get; set; }
    }
}
