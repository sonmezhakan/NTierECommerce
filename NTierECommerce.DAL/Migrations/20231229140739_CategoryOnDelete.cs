using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTierECommerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CategoryOnDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2023, 12, 29, 17, 7, 39, 45, DateTimeKind.Local).AddTicks(6497), new Guid("2bb32ff4-69bf-4349-a81a-28820430d992") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2023, 12, 29, 17, 7, 39, 45, DateTimeKind.Local).AddTicks(6557), new Guid("8183aad3-b255-4838-b56c-48cc671e5aed") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2023, 12, 29, 17, 7, 39, 45, DateTimeKind.Local).AddTicks(6558), new Guid("d0c9b6a3-88dc-447c-b532-fb72e6f2425c") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2023, 12, 29, 17, 7, 39, 45, DateTimeKind.Local).AddTicks(8292), new Guid("b6f2d169-0149-49f1-a81e-1a35eb447ee1") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2023, 12, 29, 17, 7, 39, 45, DateTimeKind.Local).AddTicks(8302), new Guid("57fd2cc0-46f2-4f0a-89fd-32ca6fd0aeb9") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2023, 12, 29, 17, 7, 39, 45, DateTimeKind.Local).AddTicks(8304), new Guid("8fd73054-1203-4346-9cb2-73d696dd1b81") });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2023, 12, 29, 13, 57, 55, 432, DateTimeKind.Local).AddTicks(2676), new Guid("e82e6b42-e54e-4ad0-a23f-f380a7dc0e36") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2023, 12, 29, 13, 57, 55, 432, DateTimeKind.Local).AddTicks(2772), new Guid("6a2f9639-6706-4afb-906b-3c718265b505") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2023, 12, 29, 13, 57, 55, 432, DateTimeKind.Local).AddTicks(2774), new Guid("3618bad7-9e25-480e-b7b8-e32d4563fb17") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2023, 12, 29, 13, 57, 55, 432, DateTimeKind.Local).AddTicks(4492), new Guid("d3945707-d5ac-4b75-855b-2580b10d2ac4") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2023, 12, 29, 13, 57, 55, 432, DateTimeKind.Local).AddTicks(4505), new Guid("956eaffa-ac34-4170-a602-646e3a86681c") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2023, 12, 29, 13, 57, 55, 432, DateTimeKind.Local).AddTicks(4507), new Guid("1cd312d9-061f-4620-bc01-fab4bed7700a") });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
