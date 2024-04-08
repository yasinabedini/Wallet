using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallet.Api.Migrations
{
    /// <inheritdoc />
    public partial class testMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 11, 36, 4, 329, DateTimeKind.Local).AddTicks(6392));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 11, 36, 4, 329, DateTimeKind.Local).AddTicks(6434));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 11, 36, 4, 329, DateTimeKind.Local).AddTicks(6443));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateAt",
                value: new DateTime(2024, 3, 11, 18, 7, 27, 378, DateTimeKind.Local).AddTicks(5056));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateAt",
                value: new DateTime(2024, 3, 11, 18, 7, 27, 378, DateTimeKind.Local).AddTicks(5089));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateAt",
                value: new DateTime(2024, 3, 11, 18, 7, 27, 378, DateTimeKind.Local).AddTicks(5095));
        }
    }
}
