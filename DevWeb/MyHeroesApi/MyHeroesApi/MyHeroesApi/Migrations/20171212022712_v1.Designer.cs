﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MyHeroesApi;
using System;

namespace MyHeroesApi.Migrations
{
    [DbContext(typeof(HeroesContext))]
    [Migration("20171212022712_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyHeroesApi.Models.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("LeagueOfHeroesId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Power")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("LeagueOfHeroesId");

                    b.ToTable("Hero");
                });

            modelBuilder.Entity("MyHeroesApi.Models.LeagueOfHeroes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("LeagueOfHeroes");
                });

            modelBuilder.Entity("MyHeroesApi.Models.Hero", b =>
                {
                    b.HasOne("MyHeroesApi.Models.LeagueOfHeroes")
                        .WithMany("Heroes")
                        .HasForeignKey("LeagueOfHeroesId");
                });
#pragma warning restore 612, 618
        }
    }
}