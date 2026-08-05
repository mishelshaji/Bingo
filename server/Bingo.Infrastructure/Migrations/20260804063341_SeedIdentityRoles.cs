using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bingo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedIdentityRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e850777-9c6e-4f70-a888-be2f8fa01670", "3e850777-9c6e-4f70-a888-be2f8fa01670", "Admin", "ADMIN" },
                    { "3e850777-9c6e-4f70-a888-be2f8fa01671", "3e850777-9c6e-4f70-a888-be2f8fa01671", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e850777-9c6e-4f70-a888-be2f8fa01670");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e850777-9c6e-4f70-a888-be2f8fa01671");
        }
    }
}
