using Microsoft.EntityFrameworkCore.Migrations;

namespace _Nuevo.DataAccsess.Migrations
{
    public partial class UpdateTargetFieldName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Targets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Targets");
        }
    }
}
