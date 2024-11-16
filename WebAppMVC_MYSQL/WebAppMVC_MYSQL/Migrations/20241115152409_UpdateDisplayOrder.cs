using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppMVC_MYSQL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDisplayOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "artsupply",
                keyColumn: "Id",
                keyValue: 3,
                column: "DisplayOrder",
                value: 3333);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "artsupply",
                keyColumn: "Id",
                keyValue: 3,
                column: "DisplayOrder",
                value: 1111);
        }
    }
}
