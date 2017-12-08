using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyHeroes.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeagueOfHeroes",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueOfHeroes", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Hero",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeagueOfHeroesCodigo = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Power = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hero", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Hero_LeagueOfHeroes_LeagueOfHeroesCodigo",
                        column: x => x.LeagueOfHeroesCodigo,
                        principalTable: "LeagueOfHeroes",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hero_LeagueOfHeroesCodigo",
                table: "Hero",
                column: "LeagueOfHeroesCodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hero");

            migrationBuilder.DropTable(
                name: "LeagueOfHeroes");
        }
    }
}
