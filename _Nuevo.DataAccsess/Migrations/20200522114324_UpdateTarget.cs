using Microsoft.EntityFrameworkCore.Migrations;

namespace _Nuevo.DataAccsess.Migrations
{
    public partial class UpdateTarget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Targets_AspNetUsers_UserId",
                table: "Targets");

            migrationBuilder.DropIndex(
                name: "IX_Status_TargetId",
                table: "Status");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Targets",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Status_TargetId",
                table: "Status",
                column: "TargetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Targets_AspNetUsers_UserId",
                table: "Targets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Targets_AspNetUsers_UserId",
                table: "Targets");

            migrationBuilder.DropIndex(
                name: "IX_Status_TargetId",
                table: "Status");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Targets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Status_TargetId",
                table: "Status",
                column: "TargetId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Targets_AspNetUsers_UserId",
                table: "Targets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
