using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kolos2APBD.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Exhibition_Artwork",
                columns: table => new
                {
                    ExhibitionId = table.Column<int>(type: "int", nullable: false),
                    ArtworkId = table.Column<int>(type: "int", nullable: false),
                    InsuranceValue = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibition_Artwork", x => new { x.ExhibitionId, x.ArtworkId });
                });

            migrationBuilder.CreateTable(
                name: "Gallery",
                columns: table => new
                {
                    GalleryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EstablishedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery", x => x.GalleryId);
                });

            migrationBuilder.CreateTable(
                name: "Artwork",
                columns: table => new
                {
                    ArtworkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    YearCreated = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artwork", x => x.ArtworkId);
                    table.ForeignKey(
                        name: "FK_Artwork_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exhibition",
                columns: table => new
                {
                    ExhibitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GalleryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumberOfArtworks = table.Column<int>(type: "int", nullable: false),
                    ExhibitionArtworkArtworkId = table.Column<int>(type: "int", nullable: true),
                    ExhibitionArtworkExhibitionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibition", x => x.ExhibitionId);
                    table.ForeignKey(
                        name: "FK_Exhibition_Exhibition_Artwork_ExhibitionArtworkExhibitionId_ExhibitionArtworkArtworkId",
                        columns: x => new { x.ExhibitionArtworkExhibitionId, x.ExhibitionArtworkArtworkId },
                        principalTable: "Exhibition_Artwork",
                        principalColumns: new[] { "ExhibitionId", "ArtworkId" });
                    table.ForeignKey(
                        name: "FK_Exhibition_Gallery_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "Gallery",
                        principalColumn: "GalleryId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "ArtistId", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Doe" },
                    { 2, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marek", "Kowalski" },
                    { 3, new DateTime(2025, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mirosław", "Krupiewnicki" }
                });

            migrationBuilder.InsertData(
                table: "Exhibition_Artwork",
                columns: new[] { "ArtworkId", "ExhibitionId", "InsuranceValue" },
                values: new object[,]
                {
                    { 1, 1, 1000m },
                    { 3, 1, 2000m },
                    { 2, 2, 3000m }
                });

            migrationBuilder.InsertData(
                table: "Gallery",
                columns: new[] { "GalleryId", "EstablishedDate", "Name" },
                values: new object[] { 1, new DateTime(2026, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wystawa1" });

            migrationBuilder.InsertData(
                table: "Artwork",
                columns: new[] { "ArtworkId", "ArtistId", "Title", "YearCreated" },
                values: new object[,]
                {
                    { 1, 1, "KolosNamalowany", 2004 },
                    { 2, 2, "Oobrotachsferniebieskich", 2005 },
                    { 3, 3, "Obrazobrazowy", 2006 }
                });

            migrationBuilder.InsertData(
                table: "Exhibition",
                columns: new[] { "ExhibitionId", "EndDate", "ExhibitionArtworkArtworkId", "ExhibitionArtworkExhibitionId", "GalleryId", "NumberOfArtworks", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 5, new DateTime(2026, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wystawa1" },
                    { 2, new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 6, new DateTime(2026, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wystawa2" },
                    { 3, new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 7, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wystawa3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artwork_ArtistId",
                table: "Artwork",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtworkExhibitionArtwork_ExhibitionArtworksExhibitionId_ExhibitionArtworksArtworkId",
                table: "ArtworkExhibitionArtwork",
                columns: new[] { "ExhibitionArtworksExhibitionId", "ExhibitionArtworksArtworkId" });

            migrationBuilder.CreateIndex(
                name: "IX_Exhibition_ExhibitionArtworkExhibitionId_ExhibitionArtworkArtworkId",
                table: "Exhibition",
                columns: new[] { "ExhibitionArtworkExhibitionId", "ExhibitionArtworkArtworkId" });

            migrationBuilder.CreateIndex(
                name: "IX_Exhibition_GalleryId",
                table: "Exhibition",
                column: "GalleryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtworkExhibitionArtwork");

            migrationBuilder.DropTable(
                name: "Exhibition");

            migrationBuilder.DropTable(
                name: "Artwork");

            migrationBuilder.DropTable(
                name: "Exhibition_Artwork");

            migrationBuilder.DropTable(
                name: "Gallery");

            migrationBuilder.DropTable(
                name: "Artist");
        }
    }
}
