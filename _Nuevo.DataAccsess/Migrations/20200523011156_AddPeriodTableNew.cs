using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _Nuevo.DataAccsess.Migrations
{
    public partial class AddPeriodTableNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndOfPeriod",
                table: "Targets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartOfPeriod",
                table: "Targets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndOfPeriod",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "StartOfPeriod",
                table: "Targets");
        }
    }
}
