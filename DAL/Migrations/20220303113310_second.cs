using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 1,
                column: "ExpenseDate",
                value: new DateTime(2022, 3, 3, 12, 33, 10, 366, DateTimeKind.Local).AddTicks(8233));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 2,
                column: "ExpenseDate",
                value: new DateTime(2022, 3, 3, 12, 33, 10, 366, DateTimeKind.Local).AddTicks(8284));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 3,
                column: "ExpenseDate",
                value: new DateTime(2022, 3, 3, 12, 33, 10, 366, DateTimeKind.Local).AddTicks(8286));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 4,
                column: "ExpenseDate",
                value: new DateTime(2022, 3, 3, 12, 33, 10, 366, DateTimeKind.Local).AddTicks(8289));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 1,
                column: "ExpenseDate",
                value: new DateTime(2022, 3, 3, 12, 18, 52, 404, DateTimeKind.Local).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 2,
                column: "ExpenseDate",
                value: new DateTime(2022, 3, 3, 12, 18, 52, 404, DateTimeKind.Local).AddTicks(5438));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 3,
                column: "ExpenseDate",
                value: new DateTime(2022, 3, 3, 12, 18, 52, 404, DateTimeKind.Local).AddTicks(5440));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 4,
                column: "ExpenseDate",
                value: new DateTime(2022, 3, 3, 12, 18, 52, 404, DateTimeKind.Local).AddTicks(5442));
        }
    }
}
