using Microsoft.EntityFrameworkCore;
using MyHeroes.Map;
using MyHeroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHeroes
{
    public class HeroesContext : DbContext
    {
        public HeroesContext(DbContextOptions<HeroesContext> options) : base(options) { }

        //public DbSet<Hero> Heroes { get; set; }
        //public DbSet<LeagueOfHeroes> LeagueOfHeroes { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        //    optionsBuilder.UseSqlServer("Data Source = heroes.db");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new HeroMap(modelBuilder.Entity<Hero>());
            new LeagueOfHeroesMap(modelBuilder.Entity<LeagueOfHeroes>());
        }

        //public DbSet<Hero> Heroes { get; set; }
        //public DbSet<LeagueOfHeroes> LeagueOfHeroes { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        //    optionsBuilder.UseSqlServer("Data Source = heroes.db");
        //}

        public DbSet<MyHeroes.Models.Hero> Hero { get; set; }

        //public DbSet<Hero> Heroes { get; set; }
        //public DbSet<LeagueOfHeroes> LeagueOfHeroes { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        //    optionsBuilder.UseSqlServer("Data Source = heroes.db");
        //}

        public DbSet<MyHeroes.Models.LeagueOfHeroes> LeagueOfHeroes { get; set; }
    }
}
