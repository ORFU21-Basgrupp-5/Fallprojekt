using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExpenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpenseDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpenseBalanceChange = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CategoryExp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ExpenseId);
                    table.ForeignKey(
                        name: "FK_Expenses_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    IncomeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncomeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IncomeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncomeBalanceChange = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CategoryInc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.IncomeId);
                    table.ForeignKey(
                        name: "FK_Incomes_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId");
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "Balance", "Name" },
                values: new object[] { 1, 0, "Lönekonto" });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "ExpenseId", "AccountId", "CategoryExp", "ExpenseBalanceChange", "ExpenseDate", "ExpenseDescription" },
                values: new object[,]
                {
                    { 1, 1, 0, 2200, new DateTime(2022, 3, 3, 12, 18, 52, 404, DateTimeKind.Local).AddTicks(5394), "Laga bil" },
                    { 2, 1, 0, 500, new DateTime(2022, 3, 3, 12, 18, 52, 404, DateTimeKind.Local).AddTicks(5438), "Kläder" },
                    { 3, 1, 0, 300, new DateTime(2022, 3, 3, 12, 18, 52, 404, DateTimeKind.Local).AddTicks(5440), "Mat" },
                    { 4, 1, 0, 400, new DateTime(2022, 3, 3, 12, 18, 52, 404, DateTimeKind.Local).AddTicks(5442), "Spel" }
                });

            migrationBuilder.InsertData(
                table: "Incomes",
                columns: new[] { "IncomeId", "AccountId", "CategoryInc", "IncomeBalanceChange", "IncomeDate", "IncomeDescription" },
                values: new object[,]
                {
                    { 1, 1, 0, 20000, new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Local), "Lön" },
                    { 2, 1, 0, 8, new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Local), "Skatteåterbäring" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountId", "Email", "Password", "UserName" },
                values: new object[] { 1, 1, "Test@test.se", "rm/sAiqLgg4nwxJ20sht7IuoLJESlJ54I6QksDKmiQk=@jB1fjqC/s+7s+frCkBnQnw==", "TestKonto1" });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_AccountId",
                table: "Expenses",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_AccountId",
                table: "Incomes",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountId",
                table: "Users",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
