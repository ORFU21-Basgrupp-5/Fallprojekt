using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class Added_emailconstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 1,
                column: "ExpenseDate",
                value: new DateTime(2022, 3, 1, 14, 10, 3, 336, DateTimeKind.Local).AddTicks(8856));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 2,
                column: "ExpenseDate",
                value: new DateTime(2022, 3, 1, 14, 10, 3, 336, DateTimeKind.Local).AddTicks(8901));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 3,
                column: "ExpenseDate",
                value: new DateTime(2022, 3, 1, 14, 10, 3, 336, DateTimeKind.Local).AddTicks(8904));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 4,
                column: "ExpenseDate",
                value: new DateTime(2022, 3, 1, 14, 10, 3, 336, DateTimeKind.Local).AddTicks(8909));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "IncomeId",
                keyValue: 1,
                column: "IncomeDate",
                value: new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "IncomeId",
                keyValue: 2,
                column: "IncomeDate",
                value: new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 1,
                column: "ExpenseDate",
                value: new DateTime(2022, 2, 16, 14, 44, 28, 807, DateTimeKind.Local).AddTicks(6373));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 2,
                column: "ExpenseDate",
                value: new DateTime(2022, 2, 16, 14, 44, 28, 807, DateTimeKind.Local).AddTicks(6423));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 3,
                column: "ExpenseDate",
                value: new DateTime(2022, 2, 16, 14, 44, 28, 807, DateTimeKind.Local).AddTicks(6427));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 4,
                column: "ExpenseDate",
                value: new DateTime(2022, 2, 16, 14, 44, 28, 807, DateTimeKind.Local).AddTicks(6430));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "IncomeId",
                keyValue: 1,
                column: "IncomeDate",
                value: new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "IncomeId",
                keyValue: 2,
                column: "IncomeDate",
                value: new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
