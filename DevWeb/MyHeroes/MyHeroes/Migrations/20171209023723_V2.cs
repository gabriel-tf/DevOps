using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyHeroes.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hero_LeagueOfHeroes_LeagueOfHeroesCodigo",
                table: "Hero");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "LeagueOfHeroes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LeagueOfHeroesCodigo",
                table: "Hero",
                newName: "LeagueOfHeroesId");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "Hero",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Hero_LeagueOfHeroesCodigo",
                table: "Hero",
                newName: "IX_Hero_LeagueOfHeroesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hero_LeagueOfHeroes_LeagueOfHeroesId",
                table: "Hero",
                column: "LeagueOfHeroesId",
                principalTable: "LeagueOfHeroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hero_LeagueOfHeroes_LeagueOfHeroesId",
                table: "Hero");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LeagueOfHeroes",
                newName: "Codigo");

            migrationBuilder.RenameColumn(
                name: "LeagueOfHeroesId",
                table: "Hero",
                newName: "LeagueOfHeroesCodigo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Hero",
                newName: "Codigo");

            migrationBuilder.RenameIndex(
                name: "IX_Hero_LeagueOfHeroesId",
                table: "Hero",
                newName: "IX_Hero_LeagueOfHeroesCodigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Hero_LeagueOfHeroes_LeagueOfHeroesCodigo",
                table: "Hero",
                column: "LeagueOfHeroesCodigo",
                principalTable: "LeagueOfHeroes",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
