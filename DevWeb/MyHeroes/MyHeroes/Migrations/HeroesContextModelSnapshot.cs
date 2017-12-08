﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MyHeroes;
using System;

namespace MyHeroes.Migrations
{
    [DbContext(typeof(HeroesContext))]
    partial class HeroesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyHeroes.Models.Hero", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("LeagueOfHeroesCodigo");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Power")
                        .IsRequired();

                    b.HasKey("Codigo");

                    b.HasIndex("LeagueOfHeroesCodigo");

                    b.ToTable("Hero");
                });

            modelBuilder.Entity("MyHeroes.Models.LeagueOfHeroes", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Codigo");

                    b.ToTable("LeagueOfHeroes");
                });

            modelBuilder.Entity("MyHeroes.Models.Hero", b =>
                {
                    b.HasOne("MyHeroes.Models.LeagueOfHeroes")
                        .WithMany("Heroes")
                        .HasForeignKey("LeagueOfHeroesCodigo");
                });
#pragma warning restore 612, 618
        }
    }
}
