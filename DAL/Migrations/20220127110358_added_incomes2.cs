using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class added_incomes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 1,
                column: "ExpenseDate",
                value: new DateTime(2022, 1, 27, 12, 3, 58, 51, DateTimeKind.Local).AddTicks(230));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 2,
                column: "ExpenseDate",
                value: new DateTime(2022, 1, 27, 12, 3, 58, 51, DateTimeKind.Local).AddTicks(264));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 3,
                column: "ExpenseDate",
                value: new DateTime(2022, 1, 27, 12, 3, 58, 51, DateTimeKind.Local).AddTicks(266));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 4,
                column: "ExpenseDate",
                value: new DateTime(2022, 1, 27, 12, 3, 58, 51, DateTimeKind.Local).AddTicks(268));

            migrationBuilder.InsertData(
                table: "Incomes",
                columns: new[] { "IncomeId", "AccountId", "IncomeBalanceChange", "IncomeDate", "IncomeDescription" },
                values: new object[,]
                {
                    { 1, 1, 20000, new DateTime(2022, 1, 27, 0, 0, 0, 0, DateTimeKind.Local), "Lön" },
                    { 2, 1, 8, new DateTime(2022, 1, 27, 0, 0, 0, 0, DateTimeKind.Local), "Skatteåterbäring" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Incomes",
                keyColumn: "IncomeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Incomes",
                keyColumn: "IncomeId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 1,
                column: "ExpenseDate",
                value: new DateTime(2022, 1, 27, 12, 0, 26, 899, DateTimeKind.Local).AddTicks(3489));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 2,
                column: "ExpenseDate",
                value: new DateTime(2022, 1, 27, 12, 0, 26, 899, DateTimeKind.Local).AddTicks(3519));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 3,
                column: "ExpenseDate",
                value: new DateTime(2022, 1, 27, 12, 0, 26, 899, DateTimeKind.Local).AddTicks(3521));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 4,
                column: "ExpenseDate",
                value: new DateTime(2022, 1, 27, 12, 0, 26, 899, DateTimeKind.Local).AddTicks(3523));
        }
    }
}
