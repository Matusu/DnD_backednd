using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class badRelationFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterHasSpells_User_UserId",
                table: "CharacterHasSpells");

            migrationBuilder.DropIndex(
                name: "IX_CharacterHasSpells_UserId",
                table: "CharacterHasSpells");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CharacterHasSpells");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CharacterHasSpells",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterHasSpells_UserId",
                table: "CharacterHasSpells",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterHasSpells_User_UserId",
                table: "CharacterHasSpells",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
