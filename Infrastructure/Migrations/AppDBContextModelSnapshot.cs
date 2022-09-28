﻿// <auto-generated />
using System;
using Domain.Constants;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "purpose", new[] { "educational", "no_educational" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "room_type", new[] { "lecture", "for_partical_training", "gym", "canteen" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Equipment", b =>
                {
                    b.Property<int>("InventoryNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InventoryNumber"));

                    b.Property<DateTime>("CommissioningDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EquipmentCategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EquipmentRoomNumber")
                        .HasColumnType("integer");

                    b.Property<int>("EquipmentWorkerId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("SerialNumber")
                        .HasColumnType("integer");

                    b.HasKey("InventoryNumber");

                    b.HasIndex("EquipmentCategoryName");

                    b.HasIndex("EquipmentRoomNumber");

                    b.HasIndex("EquipmentWorkerId");

                    b.ToTable("Equipment", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.EquipmentCategory", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.ToTable("EquipmentCategory", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.EquipmentFinanciallyResponsiblePersonChangeHistoryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ChangeTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CurrentFinanciallyResponsiblePersonId")
                        .HasColumnType("integer");

                    b.Property<int>("EquipmentInventoryNumber")
                        .HasColumnType("integer");

                    b.Property<int>("PreviousFinanciallyResponsiblePersonId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("EquipmentFinanciallyResponsiblePersonChangeHistoryItem", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.EquipmentMovementHistoryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrentRoomNumber")
                        .HasColumnType("integer");

                    b.Property<int>("EquipmentInventoryNumber")
                        .HasColumnType("integer");

                    b.Property<DateTime>("MovementTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PreviousRoomNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("EquipmentMovementHistoryItem", (string)null);
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Purpose>("Purpose")
                        .HasColumnType("purpose");

                    b.Property<RoomType>("RoomType")
                        .HasColumnType("room_type");

                    b.Property<string>("SubdivisionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UniversityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Number");

                    b.HasIndex("SubdivisionName");

                    b.HasIndex("UniversityName");

                    b.ToTable("Room", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.RoomFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<int>("CurrentRoomNumber")
                        .HasColumnType("integer");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CurrentRoomNumber")
                        .IsUnique();

                    b.ToTable("RoomFile");
                });

            modelBuilder.Entity("Domain.Entities.Subdivision", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("UniversityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.HasIndex("UniversityName");

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

                    b.Property<Purpose>("Purpose")
                        .HasColumnType("purpose");

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

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SubdivisionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SubdivisionName");

                    b.ToTable("Worker", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Equipment", b =>
                {
                    b.HasOne("Domain.Entities.EquipmentCategory", null)
                        .WithMany("CurrentCategoryEquipments")
                        .HasForeignKey("EquipmentCategoryName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Room", null)
                        .WithMany("RoomEquipment")
                        .HasForeignKey("EquipmentRoomNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Worker", null)
                        .WithMany("CurrentWorkerEquipments")
                        .HasForeignKey("EquipmentWorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Room", b =>
                {
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
                });

            modelBuilder.Entity("Domain.Entities.RoomFile", b =>
                {
                    b.HasOne("Domain.Entities.Room", null)
                        .WithOne("FloorPlan")
                        .HasForeignKey("Domain.Entities.RoomFile", "CurrentRoomNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Subdivision", b =>
                {
                    b.HasOne("Domain.Entities.UniversityBuilding", null)
                        .WithMany("IncomingSubdivisions")
                        .HasForeignKey("UniversityName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("Domain.Entities.Subdivision", null)
                        .WithMany("IncomingWorkers")
                        .HasForeignKey("SubdivisionName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Equipment", b =>
                {
                    b.Navigation("WhereUsed")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.EquipmentCategory", b =>
                {
                    b.Navigation("CurrentCategoryEquipments");
                });

            modelBuilder.Entity("Domain.Entities.Room", b =>
                {
                    b.Navigation("FloorPlan")
                        .IsRequired();

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

                    b.Navigation("IncomingSubdivisions");
                });

            modelBuilder.Entity("Domain.Entities.Worker", b =>
                {
                    b.Navigation("CurrentWorkerEquipments");
                });
#pragma warning restore 612, 618
        }
    }
}
