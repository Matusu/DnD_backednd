using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class connectionTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_Spell_SpellId",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_HasFeature_Class_ClassId",
                table: "HasFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_HasFeature_Race_RaceId",
                table: "HasFeature");

            migrationBuilder.DropIndex(
                name: "IX_Class_SpellId",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "ClassFeature",
                table: "HasFeature");

            migrationBuilder.DropColumn(
                name: "RaceFeature",
                table: "HasFeature");

            migrationBuilder.DropColumn(
                name: "SpellId",
                table: "Class");

            migrationBuilder.AlterColumn<int>(
                name: "RaceId",
                table: "HasFeature",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "HasFeature",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HasFeature_Class_ClassId",
                table: "HasFeature",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HasFeature_Race_RaceId",
                table: "HasFeature",
                column: "RaceId",
                principalTable: "Race",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HasFeature_Class_ClassId",
                table: "HasFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_HasFeature_Race_RaceId",
                table: "HasFeature");

            migrationBuilder.AlterColumn<int>(
                name: "RaceId",
                table: "HasFeature",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "HasFeature",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<bool>(
                name: "ClassFeature",
                table: "HasFeature",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RaceFeature",
                table: "HasFeature",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SpellId",
                table: "Class",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Class_SpellId",
                table: "Class",
                column: "SpellId");

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Spell_SpellId",
                table: "Class",
                column: "SpellId",
                principalTable: "Spell",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HasFeature_Class_ClassId",
                table: "HasFeature",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HasFeature_Race_RaceId",
                table: "HasFeature",
                column: "RaceId",
                principalTable: "Race",
                principalColumn: "Id");
        }
    }
}
