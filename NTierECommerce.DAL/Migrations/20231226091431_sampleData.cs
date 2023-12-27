using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NTierECommerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class sampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreatedComputerName", "CreatedDate", "CreatedIpAddress", "Description", "IsActive", "MasterId", "Status", "UpdatedComputerName", "UpdatedDate", "UpdatedIpAddress" },
                values: new object[,]
                {
                    { 1, "Giyim", "tanımsız", new DateTime(2023, 12, 26, 12, 14, 31, 666, DateTimeKind.Local).AddTicks(331), "tanımsız", "Yazlık, kışlık, renkli, renksiz giyim ürünleri", true, new Guid("a3eec1fc-4667-419f-ab0b-8b1ac8f93836"), 0, "tanımsız", null, "tanımsız" },
                    { 2, "Teknoloji", "tanımsız", new DateTime(2023, 12, 26, 12, 14, 31, 666, DateTimeKind.Local).AddTicks(381), "tanımsız", "Tablet, Telefon, bilgisayar", true, new Guid("f5de8235-7078-41a4-b16a-a0d953e8db5e"), 0, "tanımsız", null, "tanımsız" },
                    { 3, "Kozmetik", "tanımsız", new DateTime(2023, 12, 26, 12, 14, 31, 666, DateTimeKind.Local).AddTicks(385), "tanımsız", "parfüm, ruj, falan filan", true, new Guid("60160a49-4a1b-46a7-8eea-1721f7f6bc18"), 0, "tanımsız", null, "tanımsız" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedComputerName", "CreatedDate", "CreatedIpAddress", "ImagePath", "IsActive", "MasterId", "ProductName", "Status", "UnitPrice", "UnitsInStock", "UpdatedComputerName", "UpdatedDate", "UpdatedIpAddress" },
                values: new object[,]
                {
                    { 1, 1, "tanımsız", new DateTime(2023, 12, 26, 12, 14, 31, 666, DateTimeKind.Local).AddTicks(3189), "tanımsız", "https://productimages.hepsiburada.net/s/113/550/110000060380106.jpg", true, new Guid("c31c6b96-41fd-42c1-b45f-a58d7c54c379"), "Nike Airmax", 0, 4000m, (short)500, "tanımsız", null, "tanımsız" },
                    { 2, 2, "tanımsız", new DateTime(2023, 12, 26, 12, 14, 31, 666, DateTimeKind.Local).AddTicks(3217), "tanımsız", "https://productimages.hepsiburada.net/s/498/550/110000549694124.jpg", true, new Guid("7373bfbf-072f-4597-aa22-00aea34a1a74"), "Lenovo", 0, 30000m, (short)50, "tanımsız", null, "tanımsız" },
                    { 3, 3, "tanımsız", new DateTime(2023, 12, 26, 12, 14, 31, 666, DateTimeKind.Local).AddTicks(3221), "tanımsız", "https://productimages.hepsiburada.net/s/416/550/110000445267488.jpg", true, new Guid("9fc76efe-de22-4450-8802-6fc7f3238e28"), "MAC Ruj", 0, 2000m, (short)10, "tanımsız", null, "tanımsız" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
