using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryInc",
                table: "Incomes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryExp",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 1,
                column: "ExpenseDate",
                value: new DateTime(2022, 2, 10, 12, 6, 42, 930, DateTimeKind.Local).AddTicks(7056));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 2,
                column: "ExpenseDate",
                value: new DateTime(2022, 2, 10, 12, 6, 42, 930, DateTimeKind.Local).AddTicks(7099));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 3,
                column: "ExpenseDate",
                value: new DateTime(2022, 2, 10, 12, 6, 42, 930, DateTimeKind.Local).AddTicks(7102));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 4,
                column: "ExpenseDate",
                value: new DateTime(2022, 2, 10, 12, 6, 42, 930, DateTimeKind.Local).AddTicks(7106));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "IncomeId",
                keyValue: 1,
                column: "IncomeDate",
                value: new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Incomes",
                keyColumn: "IncomeId",
                keyValue: 2,
                column: "IncomeDate",
                value: new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryInc",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "CategoryExp",
                table: "Expenses");

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
    }
}
