using Microsoft.EntityFrameworkCore.Migrations;

namespace _Nuevo.DataAccsess.Migrations
{
    public partial class AddPeriodTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PeriodId",
                table: "Targets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Second = table.Column<long>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
