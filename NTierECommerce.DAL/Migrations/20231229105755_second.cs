using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTierECommerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UnitsInStock",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

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
                columns: new[] { "CreatedDate", "MasterId", "UnitsInStock" },
                values: new object[] { new DateTime(2023, 12, 29, 13, 57, 55, 432, DateTimeKind.Local).AddTicks(4492), new Guid("d3945707-d5ac-4b75-855b-2580b10d2ac4"), 500 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "MasterId", "UnitsInStock" },
                values: new object[] { new DateTime(2023, 12, 29, 13, 57, 55, 432, DateTimeKind.Local).AddTicks(4505), new Guid("956eaffa-ac34-4170-a602-646e3a86681c"), 50 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "MasterId", "UnitsInStock" },
                values: new object[] { new DateTime(2023, 12, 29, 13, 57, 55, 432, DateTimeKind.Local).AddTicks(4507), new Guid("1cd312d9-061f-4620-bc01-fab4bed7700a"), 10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "UnitsInStock",
                table: "Products",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2023, 12, 26, 12, 14, 31, 666, DateTimeKind.Local).AddTicks(331), new Guid("a3eec1fc-4667-419f-ab0b-8b1ac8f93836") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2023, 12, 26, 12, 14, 31, 666, DateTimeKind.Local).AddTicks(381), new Guid("f5de8235-7078-41a4-b16a-a0d953e8db5e") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2023, 12, 26, 12, 14, 31, 666, DateTimeKind.Local).AddTicks(385), new Guid("60160a49-4a1b-46a7-8eea-1721f7f6bc18") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "MasterId", "UnitsInStock" },
                values: new object[] { new DateTime(2023, 12, 26, 12, 14, 31, 666, DateTimeKind.Local).AddTicks(3189), new Guid("c31c6b96-41fd-42c1-b45f-a58d7c54c379"), (short)500 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "MasterId", "UnitsInStock" },
                values: new object[] { new DateTime(2023, 12, 26, 12, 14, 31, 666, DateTimeKind.Local).AddTicks(3217), new Guid("7373bfbf-072f-4597-aa22-00aea34a1a74"), (short)50 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "MasterId", "UnitsInStock" },
                values: new object[] { new DateTime(2023, 12, 26, 12, 14, 31, 666, DateTimeKind.Local).AddTicks(3221), new Guid("9fc76efe-de22-4450-8802-6fc7f3238e28"), (short)10 });
        }
    }
}
