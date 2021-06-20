﻿// <auto-generated />
using System;
using HomeAccouting.BusinessLogic.EF.AppLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeAccouting.BusinessLogic.EF.Migrations
{
    [DbContext(typeof(DomainContext))]
    [Migration("20210620141048_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HomeAccouting.BusinessLogic.EF.Domain.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("HomeAccouting.BusinessLogic.EF.Domain.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("HomeAccouting.BusinessLogic.EF.Domain.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreditAccountId")
                        .HasColumnType("int");

                    b.Property<int?>("DebetAccountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExecutionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreditAccountId");

                    b.HasIndex("DebetAccountId");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("HomeAccouting.BusinessLogic.EF.Domain.PropertyPriceChange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Delta")
                        .HasColumnType("int");

                    b.Property<int?>("PropertyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("PricesChanges");
                });

            modelBuilder.Entity("HomeAccouting.BusinessLogic.EF.Domain.Cash", b =>
                {
                    b.HasBaseType("HomeAccouting.BusinessLogic.EF.Domain.Account");

                    b.Property<int>("Banknotes")
                        .HasColumnType("int");

                    b.Property<int>("Monets")
                        .HasColumnType("int");

                    b.ToTable("Cashes");
                });

            modelBuilder.Entity("HomeAccouting.BusinessLogic.EF.Domain.Deposit", b =>
                {
                    b.HasBaseType("HomeAccouting.BusinessLogic.EF.Domain.Account");

                    b.Property<int?>("BankId")
                        .HasColumnType("int");

                    b.Property<string>("NumberOfBankAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Percent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasIndex("BankId");

                    b.ToTable("Deposites");
                });

            modelBuilder.Entity("HomeAccouting.BusinessLogic.EF.Domain.Property", b =>
                {
                    b.HasBaseType("HomeAccouting.BusinessLogic.EF.Domain.Account");

                    b.Property<int>("BaseState")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("HomeAccouting.BusinessLogic.EF.Domain.Operation", b =>
                {
                    b.HasOne("HomeAccouting.BusinessLogic.EF.Domain.Account", "CreditAccount")
                        .WithMany("CreditOperations")
                        .HasForeignKey("CreditAccountId");

                    b.HasOne("HomeAccouting.BusinessLogic.EF.Domain.Account", "DebetAccount")
                        .WithMany("DebetOperations")
                        .HasForeignKey("DebetAccountId");

                    b.Navigation("CreditAccount");

                    b.Navigation("DebetAccount");
                });

            modelBuilder.Entity("HomeAccouting.BusinessLogic.EF.Domain.PropertyPriceChange", b =>
                {
                    b.HasOne("HomeAccouting.BusinessLogic.EF.Domain.Property", null)
                        .WithMany("PropertyPriceChanges")
                        .HasForeignKey("PropertyId");
                });

            modelBuilder.Entity("HomeAccouting.BusinessLogic.EF.Domain.Cash", b =>
                {
                    b.HasOne("HomeAccouting.BusinessLogic.EF.Domain.Account", null)
                        .WithOne()
                        .HasForeignKey("HomeAccouting.BusinessLogic.EF.Domain.Cash", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HomeAccouting.BusinessLogic.EF.Domain.Deposit", b =>
                {
                    b.HasOne("HomeAccouting.BusinessLogic.EF.Domain.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId");

                    b.HasOne("HomeAccouting.BusinessLogic.EF.Domain.Account", null)
                        .WithOne()
                        .HasForeignKey("HomeAccouting.BusinessLogic.EF.Domain.Deposit", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("HomeAccouting.BusinessLogic.EF.Domain.Property", b =>
                {
                    b.HasOne("HomeAccouting.BusinessLogic.EF.Domain.Account", null)
                        .WithOne()
                        .HasForeignKey("HomeAccouting.BusinessLogic.EF.Domain.Property", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HomeAccouting.BusinessLogic.EF.Domain.Account", b =>
                {
                    b.Navigation("CreditOperations");

                    b.Navigation("DebetOperations");
                });

            modelBuilder.Entity("HomeAccouting.BusinessLogic.EF.Domain.Property", b =>
                {
                    b.Navigation("PropertyPriceChanges");
                });
#pragma warning restore 612, 618
        }
    }
}