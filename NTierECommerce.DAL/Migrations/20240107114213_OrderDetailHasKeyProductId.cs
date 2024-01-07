using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTierECommerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class OrderDetailHasKeyProductId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 1, 7, 14, 42, 13, 741, DateTimeKind.Local).AddTicks(2674), new Guid("1a90d52c-6880-432d-8e26-41476886f5a4") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 1, 7, 14, 42, 13, 741, DateTimeKind.Local).AddTicks(2725), new Guid("f4f912a4-505f-4742-8183-da230cf2f9a6") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 1, 7, 14, 42, 13, 741, DateTimeKind.Local).AddTicks(2727), new Guid("ff94b53d-5793-4316-afcc-45501ff8e656") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 1, 7, 14, 42, 13, 741, DateTimeKind.Local).AddTicks(4229), new Guid("8414d4c5-7b5c-4db3-901d-95193ad93ae1") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 1, 7, 14, 42, 13, 741, DateTimeKind.Local).AddTicks(4255), new Guid("2f48c333-42c7-4e81-811d-82b16cba9e5d") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 1, 7, 14, 42, 13, 741, DateTimeKind.Local).AddTicks(4258), new Guid("91c74ea1-9427-45a4-b853-10ee678f9a5b") });

            migrationBuilder.UpdateData(
                table: "Shippers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 1, 7, 14, 42, 13, 741, DateTimeKind.Local).AddTicks(4604), new Guid("1d79e85d-f14e-41b8-b48b-9614fcd8b867") });

            migrationBuilder.UpdateData(
                table: "Shippers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 1, 7, 14, 42, 13, 741, DateTimeKind.Local).AddTicks(4609), new Guid("bb9cac83-ed8b-4621-a779-d7c4701bce5b") });

            migrationBuilder.UpdateData(
                table: "Shippers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 1, 7, 14, 42, 13, 741, DateTimeKind.Local).AddTicks(4610), new Guid("c1fc68b2-ed3d-4edb-a657-4fdd4fdc7a7f") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 1, 6, 21, 36, 20, 186, DateTimeKind.Local).AddTicks(8578), new Guid("67beb98e-112f-44ca-a50b-4a9fb7e75684") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 1, 6, 21, 36, 20, 186, DateTimeKind.Local).AddTicks(8628), new Guid("11bea172-551e-4c68-aca6-ab9ec537525b") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 1, 6, 21, 36, 20, 186, DateTimeKind.Local).AddTicks(8629), new Guid("332ac5a6-0896-4bec-b699-6ae32ba66d9d") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 1, 6, 21, 36, 20, 187, DateTimeKind.Local).AddTicks(195), new Guid("a98474f1-c0e6-491f-8f26-0eafb9b15144") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 1, 6, 21, 36, 20, 187, DateTimeKind.Local).AddTicks(205), new Guid("886e00c2-d966-4fd4-8be3-9623ca730d0d") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 1, 6, 21, 36, 20, 187, DateTimeKind.Local).AddTicks(207), new Guid("73e7021a-e186-4a2e-abe9-06f13cc05f91") });

            migrationBuilder.UpdateData(
                table: "Shippers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 1, 6, 21, 36, 20, 187, DateTimeKind.Local).AddTicks(647), new Guid("3caaac48-471f-4187-82dd-59986648588d") });

            migrationBuilder.UpdateData(
                table: "Shippers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 1, 6, 21, 36, 20, 187, DateTimeKind.Local).AddTicks(653), new Guid("109b50d5-4204-4d78-b4c1-0f5f52842499") });

            migrationBuilder.UpdateData(
                table: "Shippers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "MasterId" },
                values: new object[] { new DateTime(2024, 1, 6, 21, 36, 20, 187, DateTimeKind.Local).AddTicks(654), new Guid("42244d2b-accb-4c45-8802-10206b739d3e") });
        }
    }
}
