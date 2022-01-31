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
                .HasAnnotation("ProductVersion", "6.0.1")
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

            modelBuilder.Entity("DAL.Models.Expense", b =>
                {
                    b.Property<int>("ExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpenseId"), 1L, 1);

                    b.Property<int>("AccountId")
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
                            ExpenseBalanceChange = 2200,
                            ExpenseDate = new DateTime(2022, 1, 27, 12, 3, 58, 51, DateTimeKind.Local).AddTicks(230),
                            ExpenseDescription = "Laga bil"
                        },
                        new
                        {
                            ExpenseId = 2,
                            AccountId = 1,
                            ExpenseBalanceChange = 500,
                            ExpenseDate = new DateTime(2022, 1, 27, 12, 3, 58, 51, DateTimeKind.Local).AddTicks(264),
                            ExpenseDescription = "Kläder"
                        },
                        new
                        {
                            ExpenseId = 3,
                            AccountId = 1,
                            ExpenseBalanceChange = 300,
                            ExpenseDate = new DateTime(2022, 1, 27, 12, 3, 58, 51, DateTimeKind.Local).AddTicks(266),
                            ExpenseDescription = "Mat"
                        },
                        new
                        {
                            ExpenseId = 4,
                            AccountId = 1,
                            ExpenseBalanceChange = 400,
                            ExpenseDate = new DateTime(2022, 1, 27, 12, 3, 58, 51, DateTimeKind.Local).AddTicks(268),
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
                            IncomeBalanceChange = 20000,
                            IncomeDate = new DateTime(2022, 1, 27, 0, 0, 0, 0, DateTimeKind.Local),
                            IncomeDescription = "Lön"
                        },
                        new
                        {
                            IncomeId = 2,
                            AccountId = 1,
                            IncomeBalanceChange = 8,
                            IncomeDate = new DateTime(2022, 1, 27, 0, 0, 0, 0, DateTimeKind.Local),
                            IncomeDescription = "Skatteåterbäring"
                        });
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Test@test.nu",
                            Password = "admin",
                            UserName = "TestKonto1"
                        });
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

            modelBuilder.Entity("DAL.Models.Account", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("Incomes");
                });
#pragma warning restore 612, 618
        }
    }
}
