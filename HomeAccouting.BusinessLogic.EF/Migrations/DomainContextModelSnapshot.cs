﻿// <auto-generated />
using System;
using HomeAccouting.BusinessLogic.EF.AppLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeAccouting.BusinessLogic.EF.Migrations
{
    [DbContext(typeof(DomainContext))]
    partial class DomainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("ExecutionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

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

            modelBuilder.Entity("OperationsAccounts", b =>
                {
                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<int>("OperationID")
                        .HasColumnType("int");

                    b.HasKey("AccountID", "OperationID");

                    b.HasIndex("OperationID");

                    b.ToTable("OperationsAccounts");
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

                    b.Property<int>("NumberOfBankAccount")
                        .HasColumnType("int");

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

            modelBuilder.Entity("HomeAccouting.BusinessLogic.EF.Domain.PropertyPriceChange", b =>
                {
                    b.HasOne("HomeAccouting.BusinessLogic.EF.Domain.Property", null)
                        .WithMany("PropertyPriceChanges")
                        .HasForeignKey("PropertyId");
                });

            modelBuilder.Entity("OperationsAccounts", b =>
                {
                    b.HasOne("HomeAccouting.BusinessLogic.EF.Domain.Account", null)
                        .WithMany()
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeAccouting.BusinessLogic.EF.Domain.Operation", null)
                        .WithMany()
                        .HasForeignKey("OperationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("HomeAccouting.BusinessLogic.EF.Domain.Property", b =>
                {
                    b.Navigation("PropertyPriceChanges");
                });
#pragma warning restore 612, 618
        }
    }
}
