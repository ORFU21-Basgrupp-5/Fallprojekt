using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class added_incomes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 1,
                column: "ExpenseDate",
                value: new DateTime(2022, 1, 27, 11, 56, 11, 664, DateTimeKind.Local).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 2,
                column: "ExpenseDate",
                value: new DateTime(2022, 1, 27, 11, 56, 11, 664, DateTimeKind.Local).AddTicks(4722));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 3,
                column: "ExpenseDate",
                value: new DateTime(2022, 1, 27, 11, 56, 11, 664, DateTimeKind.Local).AddTicks(4724));

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 4,
                column: "ExpenseDate",
                value: new DateTime(2022, 1, 27, 11, 56, 11, 664, DateTimeKind.Local).AddTicks(4726));
        }
    }
}
