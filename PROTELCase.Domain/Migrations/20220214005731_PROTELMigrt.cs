﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace PROTELCase.Domain.Migrations
{
    public partial class PROTELMigrt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "currencyRateItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    Rate = table.Column<decimal>(nullable: false),
                    Changes = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currencyRateItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "currencyRateItems");
        }
    }
}
