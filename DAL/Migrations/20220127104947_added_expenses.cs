using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class added_expenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "ExpenseId", "AccountId", "ExpenseBalanceChange", "ExpenseDate", "ExpenseDescription" },
                values: new object[] { 1, 1, 2200, new DateTime(2022, 1, 27, 11, 49, 47, 438, DateTimeKind.Local).AddTicks(6068), "Laga bil" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 1);
        }
    }
}
