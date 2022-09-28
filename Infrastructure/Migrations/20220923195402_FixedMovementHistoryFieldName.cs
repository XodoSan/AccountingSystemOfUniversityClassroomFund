using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FixedMovementHistoryFieldName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentFinanciallyResponsiblePersonChangeHistory");

            migrationBuilder.DropTable(
                name: "EquipmentMovementHistory");

            migrationBuilder.CreateTable(
                name: "EquipmentFinanciallyResponsiblePersonChangeHistoryItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChangeTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PreviousFinanciallyResponsiblePersonId = table.Column<int>(type: "integer", nullable: false),
                    CurrentFinanciallyResponsiblePersonId = table.Column<int>(type: "integer", nullable: false),
                    EquipmentInventoryNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentFinanciallyResponsiblePersonChangeHistoryItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentMovementHistoryItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MovementTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PreviousRoomNumber = table.Column<int>(type: "integer", nullable: false),
                    CurrentRoomNumber = table.Column<int>(type: "integer", nullable: false),
                    EquipmentInventoryNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentMovementHistoryItem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentFinanciallyResponsiblePersonChangeHistoryItem");

            migrationBuilder.DropTable(
                name: "EquipmentMovementHistoryItem");

            migrationBuilder.CreateTable(
                name: "EquipmentFinanciallyResponsiblePersonChangeHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChangeTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CurrentFinanciallyResponsiblePersonId = table.Column<int>(type: "integer", nullable: false),
                    EquipmentInventoryNumber = table.Column<int>(type: "integer", nullable: false),
                    PreviousFinanciallyResponsiblePersonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentFinanciallyResponsiblePersonChangeHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentMovementHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EquipmentInventoryNumber = table.Column<int>(type: "integer", nullable: false),
                    MovementTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PreviousRoomNumber = table.Column<int>(type: "integer", nullable: false),
                    RoomNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentMovementHistory", x => x.Id);
                });
        }
    }
}
