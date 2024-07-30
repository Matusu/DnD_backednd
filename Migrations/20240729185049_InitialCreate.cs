using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spell",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spell", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SpellId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_Spell_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spell",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campain_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClassHasSpells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SpellId = table.Column<int>(type: "integer", nullable: false),
                    ClassId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassHasSpells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassHasSpells_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassHasSpells_Spell_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spell",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HasFeature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FeatureId = table.Column<int>(type: "integer", nullable: false),
                    ClassFeature = table.Column<bool>(type: "boolean", nullable: false),
                    RaceFeature = table.Column<bool>(type: "boolean", nullable: false),
                    ClassId = table.Column<int>(type: "integer", nullable: true),
                    RaceId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HasFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HasFeature_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HasFeature_Feature_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HasFeature_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    RaceId = table.Column<int>(type: "integer", nullable: false),
                    CampainId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Streangth = table.Column<int>(type: "integer", nullable: false),
                    Dexterity = table.Column<int>(type: "integer", nullable: false),
                    Intelligence = table.Column<int>(type: "integer", nullable: false),
                    Wisdom = table.Column<int>(type: "integer", nullable: false),
                    Constitution = table.Column<int>(type: "integer", nullable: false),
                    Charisma = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_Campain_CampainId",
                        column: x => x.CampainId,
                        principalTable: "Campain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterHasSpells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SpellId = table.Column<int>(type: "integer", nullable: false),
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    Known = table.Column<bool>(type: "boolean", nullable: false),
                    Prepared = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterHasSpells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterHasSpells_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterHasSpells_Spell_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spell",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campain_UserId",
                table: "Campain",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_SpellId",
                table: "Class",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassHasSpells_ClassId",
                table: "ClassHasSpells",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassHasSpells_SpellId",
                table: "ClassHasSpells",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_HasFeature_ClassId",
                table: "HasFeature",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_HasFeature_FeatureId",
                table: "HasFeature",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_HasFeature_RaceId",
                table: "HasFeature",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_CampainId",
                table: "Character",
                column: "CampainId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_RaceId",
                table: "Character",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_UserId",
                table: "Character",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterHasSpells_CharacterId",
                table: "CharacterHasSpells",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterHasSpells_SpellId",
                table: "CharacterHasSpells",
                column: "SpellId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassHasSpells");

            migrationBuilder.DropTable(
                name: "HasFeature");

            migrationBuilder.DropTable(
                name: "CharacterHasSpells");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Feature");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Spell");

            migrationBuilder.DropTable(
                name: "Campain");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
