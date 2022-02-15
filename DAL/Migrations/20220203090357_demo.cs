using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class demo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 1,
                column: "ExpenseDate",
                value: new DateTime(2022, 2, 3, 10, 3, 57, 322, DateTimeKind.Local).AddTicks(6263));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 2,
                column: "ExpenseDate",
                value: new DateTime(2022, 2, 3, 10, 3, 57, 322, DateTimeKind.Local).AddTicks(6313));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 3,
                column: "ExpenseDate",
                value: new DateTime(2022, 2, 3, 10, 3, 57, 322, DateTimeKind.Local).AddTicks(6316));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 4,
                column: "ExpenseDate",
                value: new DateTime(2022, 2, 3, 10, 3, 57, 322, DateTimeKind.Local).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "IncomeId",
                keyValue: 1,
                column: "IncomeDate",
                value: new DateTime(2022, 2, 3, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "IncomeId",
                keyValue: 2,
                column: "IncomeDate",
                value: new DateTime(2022, 2, 3, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 1,
                column: "ExpenseDate",
                value: new DateTime(2022, 1, 31, 14, 39, 24, 461, DateTimeKind.Local).AddTicks(5305));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 2,
                column: "ExpenseDate",
                value: new DateTime(2022, 1, 31, 14, 39, 24, 461, DateTimeKind.Local).AddTicks(5339));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 3,
                column: "ExpenseDate",
                value: new DateTime(2022, 1, 31, 14, 39, 24, 461, DateTimeKind.Local).AddTicks(5341));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 4,
                column: "ExpenseDate",
                value: new DateTime(2022, 1, 31, 14, 39, 24, 461, DateTimeKind.Local).AddTicks(5343));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "IncomeId",
                keyValue: 1,
                column: "IncomeDate",
                value: new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "IncomeId",
                keyValue: 2,
                column: "IncomeDate",
                value: new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
