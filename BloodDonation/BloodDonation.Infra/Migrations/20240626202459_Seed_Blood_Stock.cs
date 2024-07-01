using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BloodDonation.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Blood_Stock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BloodStocks",
                columns: new[] { "Id", "BloodType", "CreatedAt", "MLQuantity", "RhFactor", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("177104ab-ed2f-4aee-b545-e77d6598e4e2"), "A", new DateTime(2024, 6, 26, 17, 24, 58, 880, DateTimeKind.Local).AddTicks(329), 0, "Negative", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1badbd30-4f51-4d40-baf3-d245b44b9b86"), "O", new DateTime(2024, 6, 26, 17, 24, 58, 880, DateTimeKind.Local).AddTicks(379), 0, "Positive", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2820efbd-5f72-4b10-aa11-a2b0dd4c4a0e"), "B", new DateTime(2024, 6, 26, 17, 24, 58, 880, DateTimeKind.Local).AddTicks(331), 0, "Positive", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa0ad1d-855f-41ad-9cd4-8dfd381f7a67"), "A", new DateTime(2024, 6, 26, 17, 24, 58, 880, DateTimeKind.Local).AddTicks(314), 0, "Positive", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("52380942-1b40-4cfb-931d-7496af1fe234"), "AB", new DateTime(2024, 6, 26, 17, 24, 58, 880, DateTimeKind.Local).AddTicks(335), 0, "Positive", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("60978428-f6ee-4960-84cd-41795591541e"), "B", new DateTime(2024, 6, 26, 17, 24, 58, 880, DateTimeKind.Local).AddTicks(333), 0, "Negative", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d53c7b67-d8fb-4f57-9ff7-318e70d3666f"), "O", new DateTime(2024, 6, 26, 17, 24, 58, 880, DateTimeKind.Local).AddTicks(383), 0, "Negative", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f93c7e3d-cbe7-41c8-99a1-d704185bd1ee"), "AB", new DateTime(2024, 6, 26, 17, 24, 58, 880, DateTimeKind.Local).AddTicks(357), 0, "Negative", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BloodStocks",
                keyColumn: "Id",
                keyValue: new Guid("177104ab-ed2f-4aee-b545-e77d6598e4e2"));

            migrationBuilder.DeleteData(
                table: "BloodStocks",
                keyColumn: "Id",
                keyValue: new Guid("1badbd30-4f51-4d40-baf3-d245b44b9b86"));

            migrationBuilder.DeleteData(
                table: "BloodStocks",
                keyColumn: "Id",
                keyValue: new Guid("2820efbd-5f72-4b10-aa11-a2b0dd4c4a0e"));

            migrationBuilder.DeleteData(
                table: "BloodStocks",
                keyColumn: "Id",
                keyValue: new Guid("3fa0ad1d-855f-41ad-9cd4-8dfd381f7a67"));

            migrationBuilder.DeleteData(
                table: "BloodStocks",
                keyColumn: "Id",
                keyValue: new Guid("52380942-1b40-4cfb-931d-7496af1fe234"));

            migrationBuilder.DeleteData(
                table: "BloodStocks",
                keyColumn: "Id",
                keyValue: new Guid("60978428-f6ee-4960-84cd-41795591541e"));

            migrationBuilder.DeleteData(
                table: "BloodStocks",
                keyColumn: "Id",
                keyValue: new Guid("d53c7b67-d8fb-4f57-9ff7-318e70d3666f"));

            migrationBuilder.DeleteData(
                table: "BloodStocks",
                keyColumn: "Id",
                keyValue: new Guid("f93c7e3d-cbe7-41c8-99a1-d704185bd1ee"));
        }
    }
}
