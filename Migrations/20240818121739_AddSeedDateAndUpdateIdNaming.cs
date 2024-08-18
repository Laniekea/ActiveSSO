using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ActiveSSO.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDateAndUpdateIdNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "Sessions",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "PasswordHash", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 18, 12, 17, 39, 305, DateTimeKind.Utc).AddTicks(1030), "admin@example.com", "Admin", "User", "hashed-password", new DateTime(2024, 8, 18, 12, 17, 39, 305, DateTimeKind.Utc).AddTicks(1030), "admin" },
                    { 2, new DateTime(2024, 8, 18, 12, 17, 39, 305, DateTimeKind.Utc).AddTicks(1030), "user@example.com", "Regular", "User", "hashed-password", new DateTime(2024, 8, 18, 12, 17, 39, 305, DateTimeKind.Utc).AddTicks(1030), "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sessions",
                newName: "SessionId");
        }
    }
}
