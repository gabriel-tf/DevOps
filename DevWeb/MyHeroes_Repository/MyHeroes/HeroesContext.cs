using Microsoft.EntityFrameworkCore;
using MyHeroes.Map;
using MyHeroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHeroes
{
    public class HeroesContext : DbContext, IUnitOfWork
    {
        private static DbContextOptions<HeroesContext> _options { get; set; }

        public HeroesContext(DbContextOptions<HeroesContext> options) : base(options)
        {
            if (_options == null)
                _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new HeroMap(modelBuilder.Entity<Hero>());
            new LeagueOfHeroesMap(modelBuilder.Entity<LeagueOfHeroes>());
        }

        public void Save()
        {
            base.SaveChanges();
        }

        public DbSet<MyHeroes.Models.Hero> Hero { get; set; }
        public DbSet<MyHeroes.Models.LeagueOfHeroes> LeagueOfHeroes { get; set; }
    }
}
