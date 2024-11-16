using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAppMVC_MYSQL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "artsupplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ContactNo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artsupplier", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "artsupply",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artsupply", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ArtSupplierArtSupply",
                columns: table => new
                {
                    ArtSuppliersId = table.Column<int>(type: "int", nullable: false),
                    ArtSuppliesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtSupplierArtSupply", x => new { x.ArtSuppliersId, x.ArtSuppliesId });
                    table.ForeignKey(
                        name: "FK_ArtSupplierArtSupply_artsupplier_ArtSuppliersId",
                        column: x => x.ArtSuppliersId,
                        principalTable: "artsupplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtSupplierArtSupply_artsupply_ArtSuppliesId",
                        column: x => x.ArtSuppliesId,
                        principalTable: "artsupply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "artsupplier",
                columns: new[] { "Id", "Category", "ContactNo", "Email", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Paint", "0872662523", "evans.art@gmail.com", "Evans Art Supplies", 20m, 2 },
                    { 2, "Paintbrushes", "0861273743", "fine.art@gmail.com", "Fine Art Supplies", 10m, 6 },
                    { 3, "Paper", "0834567351", "still.art@hotmail.com", "Still Art Supplies", 50m, 50 }
                });

            migrationBuilder.InsertData(
                table: "artsupply",
                columns: new[] { "Id", "CreatedDate", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1111, "Winsor & Newton" },
                    { 2, new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2222, "Faber Castell" },
                    { 3, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1111, "Premier" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtSupplierArtSupply_ArtSuppliesId",
                table: "ArtSupplierArtSupply",
                column: "ArtSuppliesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtSupplierArtSupply");

            migrationBuilder.DropTable(
                name: "artsupplier");

            migrationBuilder.DropTable(
                name: "artsupply");
        }
    }
}
