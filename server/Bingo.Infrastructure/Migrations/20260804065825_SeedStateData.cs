using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bingo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedStateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CountryId", "CreatedAt", "DeletedAt", "IsoCode", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, null, null, "IN-KL", "Kerala", null },
                    { 2L, 1L, null, null, "IN-TN", "Tamil Nadu", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
