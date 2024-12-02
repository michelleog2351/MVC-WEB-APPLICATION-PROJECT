using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyWebAppMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddWarehouseDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtSupplierArtSupply");

            migrationBuilder.DropTable(
                name: "artsupplier");

            migrationBuilder.DropTable(
                name: "artsupply");

            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "warehouse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "warehouse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductSupplier",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    SuppliersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSupplier", x => new { x.ProductsId, x.SuppliersId });
                    table.ForeignKey(
                        name: "FK_ProductSupplier_product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSupplier_supplier_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "Id", "Name", "Price", "Quantity", "WarehouseId" },
                values: new object[,]
                {
                    { 1, "Winsor & Newton", 1m, 1, null },
                    { 2, "Faber Castell", 10m, 10, null },
                    { 3, "Premier", 1m, 1, null }
                });

            migrationBuilder.InsertData(
                table: "supplier",
                columns: new[] { "Id", "ContactNo", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "0872662523", "evansart@gmail.com", "Evans Art" },
                    { 2, "0861273743", "fine.art@gmail.com", "Fine Art" },
                    { 3, "0834567351", "still.art@hotmail.com", "Still Art" }
                });

            migrationBuilder.InsertData(
                table: "warehouse",
                columns: new[] { "Id", "Address", "ContactNo", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "123, Downing Street, Dublin", "0872734567", "Ireland", "Warehouse1" },
                    { 2, "375, Beauvelgrade Street, Paris", "0834562874", "France", "Warehouse2" },
                    { 3, "421, Unter den Linden, Berlin", "0865748902", "Germany", "Warehouse3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_WarehouseId",
                table: "product",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSupplier_SuppliersId",
                table: "ProductSupplier",
                column: "SuppliersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSupplier");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "supplier");

            migrationBuilder.DropTable(
                name: "warehouse");

            migrationBuilder.CreateTable(
                name: "artsupplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artsupplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "artsupply",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artsupply", x => x.Id);
                });

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
                });

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
                    { 3, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3333, "Premier" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtSupplierArtSupply_ArtSuppliesId",
                table: "ArtSupplierArtSupply",
                column: "ArtSuppliesId");
        }
    }
}
