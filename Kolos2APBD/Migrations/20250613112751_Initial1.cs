using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kolos2APBD.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exhibition_Exhibition_Artwork_ExhibitionArtworkExhibitionId_ExhibitionArtworkArtworkId",
                table: "Exhibition");

            migrationBuilder.DropTable(
                name: "ArtworkExhibitionArtwork");

            migrationBuilder.DropIndex(
                name: "IX_Exhibition_ExhibitionArtworkExhibitionId_ExhibitionArtworkArtworkId",
                table: "Exhibition");

            migrationBuilder.DropColumn(
                name: "ExhibitionArtworkArtworkId",
                table: "Exhibition");

            migrationBuilder.DropColumn(
                name: "ExhibitionArtworkExhibitionId",
                table: "Exhibition");

            migrationBuilder.CreateIndex(
                name: "IX_Exhibition_Artwork_ArtworkId",
                table: "Exhibition_Artwork",
                column: "ArtworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exhibition_Artwork_Artwork_ArtworkId",
                table: "Exhibition_Artwork",
                column: "ArtworkId",
                principalTable: "Artwork",
                principalColumn: "ArtworkId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exhibition_Artwork_Exhibition_ExhibitionId",
                table: "Exhibition_Artwork",
                column: "ExhibitionId",
                principalTable: "Exhibition",
                principalColumn: "ExhibitionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exhibition_Artwork_Artwork_ArtworkId",
                table: "Exhibition_Artwork");

            migrationBuilder.DropForeignKey(
                name: "FK_Exhibition_Artwork_Exhibition_ExhibitionId",
                table: "Exhibition_Artwork");

            migrationBuilder.DropIndex(
                name: "IX_Exhibition_Artwork_ArtworkId",
                table: "Exhibition_Artwork");

            migrationBuilder.AddColumn<int>(
                name: "ExhibitionArtworkArtworkId",
                table: "Exhibition",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExhibitionArtworkExhibitionId",
                table: "Exhibition",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArtworkExhibitionArtwork",
                columns: table => new
                {
                    ArtworksArtworkId = table.Column<int>(type: "int", nullable: false),
                    ExhibitionArtworksExhibitionId = table.Column<int>(type: "int", nullable: false),
                    ExhibitionArtworksArtworkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtworkExhibitionArtwork", x => new { x.ArtworksArtworkId, x.ExhibitionArtworksExhibitionId, x.ExhibitionArtworksArtworkId });
                    table.ForeignKey(
                        name: "FK_ArtworkExhibitionArtwork_Artwork_ArtworksArtworkId",
                        column: x => x.ArtworksArtworkId,
                        principalTable: "Artwork",
                        principalColumn: "ArtworkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtworkExhibitionArtwork_Exhibition_Artwork_ExhibitionArtworksExhibitionId_ExhibitionArtworksArtworkId",
                        columns: x => new { x.ExhibitionArtworksExhibitionId, x.ExhibitionArtworksArtworkId },
                        principalTable: "Exhibition_Artwork",
                        principalColumns: new[] { "ExhibitionId", "ArtworkId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Exhibition",
                keyColumn: "ExhibitionId",
                keyValue: 1,
                columns: new[] { "ExhibitionArtworkArtworkId", "ExhibitionArtworkExhibitionId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exhibition",
                keyColumn: "ExhibitionId",
                keyValue: 2,
                columns: new[] { "ExhibitionArtworkArtworkId", "ExhibitionArtworkExhibitionId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Exhibition",
                keyColumn: "ExhibitionId",
                keyValue: 3,
                columns: new[] { "ExhibitionArtworkArtworkId", "ExhibitionArtworkExhibitionId" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Exhibition_ExhibitionArtworkExhibitionId_ExhibitionArtworkArtworkId",
                table: "Exhibition",
                columns: new[] { "ExhibitionArtworkExhibitionId", "ExhibitionArtworkArtworkId" });

            migrationBuilder.CreateIndex(
                name: "IX_ArtworkExhibitionArtwork_ExhibitionArtworksExhibitionId_ExhibitionArtworksArtworkId",
                table: "ArtworkExhibitionArtwork",
                columns: new[] { "ExhibitionArtworksExhibitionId", "ExhibitionArtworksArtworkId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Exhibition_Exhibition_Artwork_ExhibitionArtworkExhibitionId_ExhibitionArtworkArtworkId",
                table: "Exhibition",
                columns: new[] { "ExhibitionArtworkExhibitionId", "ExhibitionArtworkArtworkId" },
                principalTable: "Exhibition_Artwork",
                principalColumns: new[] { "ExhibitionId", "ArtworkId" });
        }
    }
}
