using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class added_expenses2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 1,
                columns: new[] { "AccountId", "ExpenseDate" },
                values: new object[] { 1, new DateTime(2022, 1, 27, 11, 56, 11, 664, DateTimeKind.Local).AddTicks(4688) });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "ExpenseId", "AccountId", "ExpenseBalanceChange", "ExpenseDate", "ExpenseDescription" },
                values: new object[,]
                {
                    { 2, 1, 500, new DateTime(2022, 1, 27, 11, 56, 11, 664, DateTimeKind.Local).AddTicks(4722), "Kläder" },
                    { 3, 1, 300, new DateTime(2022, 1, 27, 11, 56, 11, 664, DateTimeKind.Local).AddTicks(4724), "Mat" },
                    { 4, 1, 400, new DateTime(2022, 1, 27, 11, 56, 11, 664, DateTimeKind.Local).AddTicks(4726), "Spel" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 1,
                columns: new[] { "AccountId", "ExpenseDate" },
                values: new object[] { 0, new DateTime(2022, 1, 27, 11, 49, 47, 438, DateTimeKind.Local).AddTicks(6068) });
        }
    }
}
