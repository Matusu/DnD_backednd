using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Known",
                table: "CharacterHasSpells");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "Known",
                table: "CharacterHasSpells",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
