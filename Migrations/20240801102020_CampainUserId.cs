using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class CampainUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campain_User_UserId",
                table: "Campain");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Campain",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Campain_User_UserId",
                table: "Campain",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campain_User_UserId",
                table: "Campain");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Campain",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Campain_User_UserId",
                table: "Campain",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
