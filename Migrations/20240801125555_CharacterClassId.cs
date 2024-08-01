using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class CharacterClassId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Character",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Character_ClassId",
                table: "Character",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Class_ClassId",
                table: "Character",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Class_ClassId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_ClassId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Character");
        }
    }
}
