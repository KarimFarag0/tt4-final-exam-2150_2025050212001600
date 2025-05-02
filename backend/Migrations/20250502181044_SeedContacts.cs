using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedContacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ID", "Email", "FullName", "IsFavorite", "Phone" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John Doe", false, "123-456-7890" },
                    { 2, "jane.smith@example.com", "Jane Smith", false, "234-567-8901" },
                    { 3, "alice.johnson@example.com", "Alice Johnson", false, "345-678-9012" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
