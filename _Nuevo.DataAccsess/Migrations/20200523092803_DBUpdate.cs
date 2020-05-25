using Microsoft.EntityFrameworkCore.Migrations;

namespace _Nuevo.DataAccsess.Migrations
{
    public partial class DBUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Targets_Periods_PeriodId",
                table: "Targets");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.DropIndex(
                name: "IX_Targets_PeriodId",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "Targets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PeriodId",
                table: "Targets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Second = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Targets_PeriodId",
                table: "Targets",
                column: "PeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Targets_Periods_PeriodId",
                table: "Targets",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
