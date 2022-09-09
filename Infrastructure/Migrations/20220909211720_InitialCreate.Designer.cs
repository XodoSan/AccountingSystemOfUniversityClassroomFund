﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20220909211720_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Equipment", b =>
                {
                    b.Property<int>("InventoryNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InventoryNumber"));

                    b.Property<DateTimeOffset>("CommissioningDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<DateTimeOffset>("PurchaseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("integer");

                    b.Property<int>("SerialNumber")
                        .HasColumnType("integer");

                    b.HasKey("InventoryNumber");

                    b.HasIndex("RoomNumber");

                    b.ToTable("Equipment", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.EquipmentCategory", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("EquipmentAmount")
                        .HasColumnType("integer");

                    b.Property<int>("EquipmentInventoryNumber")
                        .HasColumnType("integer");

                    b.HasKey("Name");

                    b.HasIndex("EquipmentInventoryNumber")
                        .IsUnique();

                    b.ToTable("EquipmentCategory", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.EquipmentMovementHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrentRoomNumber")
                        .HasColumnType("integer");

                    b.Property<int>("EquipmentInventoryNumber")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("MovementTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PreviousRoomNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("EquipmentMovementHistory", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.FinanciallyResponsiblePersonChangeHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("ChangeTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CurrentFinanciallyResponsiblePersonId")
                        .HasColumnType("integer");

                    b.Property<int>("PreviousFinanciallyResponsiblePersonId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("FinanciallyResponsiblePersonChangeHistory", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Room", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Number"));

                    b.Property<int>("Area")
                        .HasColumnType("integer");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<int>("Floor")
                        .HasColumnType("integer");

                    b.Property<string>("FloorPlan")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Purpose")
                        .HasColumnType("integer");

                    b.Property<int>("RoomType")
                        .HasColumnType("integer");

                    b.Property<string>("SubdivisionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UniversityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Number");

                    b.HasIndex("OwnerName");

                    b.HasIndex("SubdivisionName");

                    b.HasIndex("UniversityName");

                    b.ToTable("Room", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Subdivision", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.ToTable("Subdivision", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.UniversityBuilding", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FoundationYear")
                        .HasColumnType("integer");

                    b.Property<int>("StoreysNumber")
                        .HasColumnType("integer");

                    b.HasKey("Name");

                    b.ToTable("UniversityBuilding", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Usage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EquipmentInventoryNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Instruction")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Purpose")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentInventoryNumber")
                        .IsUnique();

                    b.ToTable("Usage", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<int>("EquipmentInventoryNumber")
                        .HasColumnType("integer");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SubdivisionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentInventoryNumber")
                        .IsUnique();

                    b.HasIndex("SubdivisionName");

                    b.ToTable("Worker", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Equipment", b =>
                {
                    b.HasOne("Domain.Entities.Room", null)
                        .WithMany("RoomEquipment")
                        .HasForeignKey("RoomNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.EquipmentCategory", b =>
                {
                    b.HasOne("Domain.Entities.Equipment", null)
                        .WithOne("Category")
                        .HasForeignKey("Domain.Entities.EquipmentCategory", "EquipmentInventoryNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Room", b =>
                {
                    b.HasOne("Domain.Entities.Subdivision", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Subdivision", null)
                        .WithMany("IncomingRooms")
                        .HasForeignKey("SubdivisionName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UniversityBuilding", null)
                        .WithMany("IncomingRooms")
                        .HasForeignKey("UniversityName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Domain.Entities.Usage", b =>
                {
                    b.HasOne("Domain.Entities.Equipment", null)
                        .WithOne("WhereUsed")
                        .HasForeignKey("Domain.Entities.Usage", "EquipmentInventoryNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Worker", b =>
                {
                    b.HasOne("Domain.Entities.Equipment", null)
                        .WithOne("FinanciallyResponsiblePerson")
                        .HasForeignKey("Domain.Entities.Worker", "EquipmentInventoryNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Subdivision", null)
                        .WithMany("IncomingWorkers")
                        .HasForeignKey("SubdivisionName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Equipment", b =>
                {
                    b.Navigation("Category")
                        .IsRequired();

                    b.Navigation("FinanciallyResponsiblePerson")
                        .IsRequired();

                    b.Navigation("WhereUsed")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Room", b =>
                {
                    b.Navigation("RoomEquipment");
                });

            modelBuilder.Entity("Domain.Entities.Subdivision", b =>
                {
                    b.Navigation("IncomingRooms");

                    b.Navigation("IncomingWorkers");
                });

            modelBuilder.Entity("Domain.Entities.UniversityBuilding", b =>
                {
                    b.Navigation("IncomingRooms");
                });
#pragma warning restore 612, 618
        }
    }
}
