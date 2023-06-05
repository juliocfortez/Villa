using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Villa_API.Migrations
{
    /// <inheritdoc />
    public partial class initialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "typeWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeWords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdPassword = table.Column<int>(type: "int", nullable: false),
                    IdRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.UniqueConstraint("AK_users_UserName", x => x.UserName);
                    table.ForeignKey(
                        name: "FK_users_roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "passwords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passwords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_passwords_users_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "phrases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meaning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phrases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_phrases_users_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "verbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Infinitive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InfinitivePronunciation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Past = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PastPronunciation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PastParticiple = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PastParticiplePronunciation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRegular = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_verbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_verbs_users_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pronunciation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meaning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTypeWord = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_words_typeWords_IdTypeWord",
                        column: x => x.IdTypeWord,
                        principalTable: "typeWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_words_users_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_passwords_IdUsuario",
                table: "passwords",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_phrases_IdUsuario",
                table: "phrases",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_users_IdRole",
                table: "users",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_verbs_IdUsuario",
                table: "verbs",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_words_IdTypeWord",
                table: "words",
                column: "IdTypeWord");

            migrationBuilder.CreateIndex(
                name: "IX_words_IdUsuario",
                table: "words",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "passwords");

            migrationBuilder.DropTable(
                name: "phrases");

            migrationBuilder.DropTable(
                name: "verbs");

            migrationBuilder.DropTable(
                name: "words");

            migrationBuilder.DropTable(
                name: "typeWords");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
