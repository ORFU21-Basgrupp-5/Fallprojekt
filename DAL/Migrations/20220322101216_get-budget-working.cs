using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class getbudgetworking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 1,
                column: "ExpenseDate",
                value: new DateTime(2022, 3, 22, 11, 12, 15, 782, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 2,
                column: "ExpenseDate",
                value: new DateTime(2022, 3, 22, 11, 12, 15, 782, DateTimeKind.Local).AddTicks(1402));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 3,
                column: "ExpenseDate",
                value: new DateTime(2022, 3, 22, 11, 12, 15, 782, DateTimeKind.Local).AddTicks(1404));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 4,
                column: "ExpenseDate",
                value: new DateTime(2022, 3, 22, 11, 12, 15, 782, DateTimeKind.Local).AddTicks(1406));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "IncomeId",
                keyValue: 1,
                column: "IncomeDate",
                value: new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "IncomeId",
                keyValue: 2,
                column: "IncomeDate",
                value: new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 1,
                column: "ExpenseDate",
                value: new DateTime(2022, 3, 17, 16, 12, 16, 223, DateTimeKind.Local).AddTicks(7686));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 2,
                column: "ExpenseDate",
                value: new DateTime(2022, 3, 17, 16, 12, 16, 223, DateTimeKind.Local).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 3,
                column: "ExpenseDate",
                value: new DateTime(2022, 3, 17, 16, 12, 16, 223, DateTimeKind.Local).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 4,
                column: "ExpenseDate",
                value: new DateTime(2022, 3, 17, 16, 12, 16, 223, DateTimeKind.Local).AddTicks(7730));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "IncomeId",
                keyValue: 1,
                column: "IncomeDate",
                value: new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "IncomeId",
                keyValue: 2,
                column: "IncomeDate",
                value: new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
