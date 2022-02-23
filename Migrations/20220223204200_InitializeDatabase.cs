using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vogels_api.Migrations
{
    public partial class InitializeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ministry",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dislikes = table.Column<byte>(type: "tinyint unsigned", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ministry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ministry_Ministry_Dislikes",
                        column: x => x.Dislikes,
                        principalTable: "Ministry",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TreeBlueprints",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BasePlots = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeBlueprints", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AllianceId = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Honour = table.Column<sbyte>(type: "tinyint", nullable: false),
                    Ranking = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    Seeds = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    GoldenSeeds = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    MaxTactics = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BirdHouseBlueprints",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MinistryId = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BasePlots = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirdHouseBlueprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BirdHouseBlueprints_Ministry_MinistryId",
                        column: x => x.MinistryId,
                        principalTable: "Ministry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LawBlueprints",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MinistryId = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Requirement = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Benefit = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawBlueprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LawBlueprints_Ministry_MinistryId",
                        column: x => x.MinistryId,
                        principalTable: "Ministry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MinisterBlueprints",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MinistryId = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Trait = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BaseActions = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Premium = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinisterBlueprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MinisterBlueprints_Ministry_MinistryId",
                        column: x => x.MinistryId,
                        principalTable: "Ministry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Trees",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BlueprintId = table.Column<uint>(type: "int unsigned", nullable: false),
                    UserId = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    Level = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trees_TreeBlueprints_BlueprintId",
                        column: x => x.BlueprintId,
                        principalTable: "TreeBlueprints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Birdhouses",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BlueprintId = table.Column<uint>(type: "int unsigned", nullable: false),
                    UserId = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    Level = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birdhouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Birdhouses_BirdHouseBlueprints_BlueprintId",
                        column: x => x.BlueprintId,
                        principalTable: "BirdHouseBlueprints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Birdhouses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Law",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BlueprintId = table.Column<uint>(type: "int unsigned", nullable: false),
                    UserId = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Law", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Law_LawBlueprints_BlueprintId",
                        column: x => x.BlueprintId,
                        principalTable: "LawBlueprints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Law_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ministers",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MinisterId = table.Column<uint>(type: "int unsigned", nullable: false),
                    CustomName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Happiness = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Actions = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Xp = table.Column<uint>(type: "int unsigned", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ministers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ministers_MinisterBlueprints_MinisterId",
                        column: x => x.MinisterId,
                        principalTable: "MinisterBlueprints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BirdHouseBlueprints_MinistryId",
                table: "BirdHouseBlueprints",
                column: "MinistryId");

            migrationBuilder.CreateIndex(
                name: "IX_Birdhouses_BlueprintId",
                table: "Birdhouses",
                column: "BlueprintId");

            migrationBuilder.CreateIndex(
                name: "IX_Birdhouses_UserId",
                table: "Birdhouses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Law_BlueprintId",
                table: "Law",
                column: "BlueprintId");

            migrationBuilder.CreateIndex(
                name: "IX_Law_UserId",
                table: "Law",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LawBlueprints_MinistryId",
                table: "LawBlueprints",
                column: "MinistryId");

            migrationBuilder.CreateIndex(
                name: "IX_MinisterBlueprints_MinistryId",
                table: "MinisterBlueprints",
                column: "MinistryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ministers_MinisterId",
                table: "Ministers",
                column: "MinisterId");

            migrationBuilder.CreateIndex(
                name: "IX_Ministry_Dislikes",
                table: "Ministry",
                column: "Dislikes");

            migrationBuilder.CreateIndex(
                name: "IX_Trees_BlueprintId",
                table: "Trees",
                column: "BlueprintId");

            migrationBuilder.CreateIndex(
                name: "IX_Trees_UserId",
                table: "Trees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Birdhouses");

            migrationBuilder.DropTable(
                name: "Law");

            migrationBuilder.DropTable(
                name: "Ministers");

            migrationBuilder.DropTable(
                name: "Trees");

            migrationBuilder.DropTable(
                name: "BirdHouseBlueprints");

            migrationBuilder.DropTable(
                name: "LawBlueprints");

            migrationBuilder.DropTable(
                name: "MinisterBlueprints");

            migrationBuilder.DropTable(
                name: "TreeBlueprints");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Ministry");
        }
    }
}
