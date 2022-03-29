﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(BudgetContext))]
    partial class BudgetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DAL.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"), 1L, 1);

                    b.Property<int>("Balance")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountId = 1,
                            Balance = 0,
                            Name = "Lönekonto"
                        });
                });

            modelBuilder.Entity("DAL.Models.Budget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("BudgetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("TotalSum")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("DAL.Models.BudgetEntries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BudgeeCategory")
                        .HasColumnType("int");

                    b.Property<int?>("BudgetId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryBudgetAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.ToTable("BudgetsEntries");
                });

            modelBuilder.Entity("DAL.Models.Expense", b =>
                {
                    b.Property<int>("ExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpenseId"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryExp")
                        .HasColumnType("int");

                    b.Property<int>("ExpenseBalanceChange")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExpenseDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExpenseId");

                    b.HasIndex("AccountId");

                    b.ToTable("Expenses");

                    b.HasData(
                        new
                        {
                            ExpenseId = 1,
                            AccountId = 1,
                            CategoryExp = 0,
                            ExpenseBalanceChange = 2200,
                            ExpenseDate = new DateTime(2022, 3, 24, 8, 39, 21, 903, DateTimeKind.Local).AddTicks(4924),
                            ExpenseDescription = "Laga bil"
                        },
                        new
                        {
                            ExpenseId = 2,
                            AccountId = 1,
                            CategoryExp = 0,
                            ExpenseBalanceChange = 500,
                            ExpenseDate = new DateTime(2022, 3, 24, 8, 39, 21, 903, DateTimeKind.Local).AddTicks(4966),
                            ExpenseDescription = "Kläder"
                        },
                        new
                        {
                            ExpenseId = 3,
                            AccountId = 1,
                            CategoryExp = 0,
                            ExpenseBalanceChange = 300,
                            ExpenseDate = new DateTime(2022, 3, 24, 8, 39, 21, 903, DateTimeKind.Local).AddTicks(4968),
                            ExpenseDescription = "Mat"
                        },
                        new
                        {
                            ExpenseId = 4,
                            AccountId = 1,
                            CategoryExp = 0,
                            ExpenseBalanceChange = 400,
                            ExpenseDate = new DateTime(2022, 3, 24, 8, 39, 21, 903, DateTimeKind.Local).AddTicks(4969),
                            ExpenseDescription = "Spel"
                        });
                });

            modelBuilder.Entity("DAL.Models.Income", b =>
                {
                    b.Property<int>("IncomeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IncomeId"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryInc")
                        .HasColumnType("int");

                    b.Property<int>("IncomeBalanceChange")
                        .HasColumnType("int");

                    b.Property<DateTime>("IncomeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IncomeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IncomeId");

                    b.HasIndex("AccountId");

                    b.ToTable("Incomes");

                    b.HasData(
                        new
                        {
                            IncomeId = 1,
                            AccountId = 1,
                            CategoryInc = 0,
                            IncomeBalanceChange = 20000,
                            IncomeDate = new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            IncomeDescription = "Lön"
                        },
                        new
                        {
                            IncomeId = 2,
                            AccountId = 1,
                            CategoryInc = 0,
                            IncomeBalanceChange = 8,
                            IncomeDate = new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            IncomeDescription = "Skatteåterbäring"
                        });
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountId = 1,
                            Email = "Test@test.se",
                            Password = "rm/sAiqLgg4nwxJ20sht7IuoLJESlJ54I6QksDKmiQk=@jB1fjqC/s+7s+frCkBnQnw==",
                            UserName = "TestKonto1"
                        });
                });

            modelBuilder.Entity("DAL.Models.Budget", b =>
                {
                    b.HasOne("DAL.Models.Account", null)
                        .WithMany("Budgets")
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("DAL.Models.BudgetEntries", b =>
                {
                    b.HasOne("DAL.Models.Budget", null)
                        .WithMany("BudgetCategories")
                        .HasForeignKey("BudgetId");
                });

            modelBuilder.Entity("DAL.Models.Expense", b =>
                {
                    b.HasOne("DAL.Models.Account", "Account")
                        .WithMany("Expenses")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DAL.Models.Income", b =>
                {
                    b.HasOne("DAL.Models.Account", "Account")
                        .WithMany("Incomes")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.HasOne("DAL.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DAL.Models.Account", b =>
                {
                    b.Navigation("Budgets");

                    b.Navigation("Expenses");

                    b.Navigation("Incomes");
                });

            modelBuilder.Entity("DAL.Models.Budget", b =>
                {
                    b.Navigation("BudgetCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
