using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _Nuevo.DataAccsess.Migrations
{
    public partial class UpdateFieldName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "IsStopped",
                table: "Targets");

            migrationBuilder.AddColumn<bool>(
                name: "IsWork",
                table: "Targets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Targets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsWork",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Targets");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Targets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "Targets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsStopped",
                table: "Targets",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
