using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sol.Migrations
{
    /// <inheritdoc />
    public partial class Relations_primary_key : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimalRelation",
                columns: table => new
                {
                    PredatorId = table.Column<int>(type: "int", nullable: false),
                    PreyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalRelation", x => new { x.PredatorId, x.PreyId });
                    table.ForeignKey(
                        name: "FK_AnimalRelation_Animals_PredatorId",
                        column: x => x.PredatorId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnimalRelation_Animals_PreyId",
                        column: x => x.PreyId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Humans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MostFavoriteAnimalId = table.Column<int>(type: "int", nullable: true),
                    LeastFavoriteAnimalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Humans_Animals_LeastFavoriteAnimalId",
                        column: x => x.LeastFavoriteAnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Humans_Animals_MostFavoriteAnimalId",
                        column: x => x.MostFavoriteAnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalRelation_PredatorId",
                table: "AnimalRelation",
                column: "PredatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalRelation_PreyId",
                table: "AnimalRelation",
                column: "PreyId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_Name",
                table: "Animals",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Humans_LeastFavoriteAnimalId",
                table: "Humans",
                column: "LeastFavoriteAnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Humans_MostFavoriteAnimalId",
                table: "Humans",
                column: "MostFavoriteAnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalRelation");

            migrationBuilder.DropTable(
                name: "Humans");

            migrationBuilder.DropTable(
                name: "Animals");
        }
    }
}
