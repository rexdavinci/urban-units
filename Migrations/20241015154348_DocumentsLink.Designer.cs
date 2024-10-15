﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using fractionalized.Data;

#nullable disable

namespace fractionalized.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20241015154348_DocumentsLink")]
    partial class DocumentsLink
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("fractionalized.Models.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AvailableUnits")
                        .HasColumnType("int");

                    b.Property<string>("BuildingType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("CurrentValuation")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DividendPerUnit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("DocumentsURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExitDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastValuedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaximumPurchaseUnits")
                        .HasColumnType("int");

                    b.Property<int>("MinimumPurchaseUnits")
                        .HasColumnType("int");

                    b.Property<int>("SoldUnits")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubscribersCount")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitCost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("fractionalized.Models.BuildingUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DividendsEarned")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("buildingId")
                        .HasColumnType("int");

                    b.Property<int?>("subscriberId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("buildingId");

                    b.HasIndex("subscriberId");

                    b.ToTable("BuildingUnits");
                });

            modelBuilder.Entity("fractionalized.Models.Subscriber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Balance")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subscribers");
                });

            modelBuilder.Entity("fractionalized.Models.BuildingUnit", b =>
                {
                    b.HasOne("fractionalized.Models.Building", "building")
                        .WithMany("BuildingUnits")
                        .HasForeignKey("buildingId");

                    b.HasOne("fractionalized.Models.Subscriber", "subscriber")
                        .WithMany("BuildingUnits")
                        .HasForeignKey("subscriberId");

                    b.Navigation("building");

                    b.Navigation("subscriber");
                });

            modelBuilder.Entity("fractionalized.Models.Building", b =>
                {
                    b.Navigation("BuildingUnits");
                });

            modelBuilder.Entity("fractionalized.Models.Subscriber", b =>
                {
                    b.Navigation("BuildingUnits");
                });
#pragma warning restore 612, 618
        }
    }
}
