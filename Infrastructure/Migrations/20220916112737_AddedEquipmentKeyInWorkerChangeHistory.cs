using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddedEquipmentKeyInWorkerChangeHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinanciallyResponsiblePersonChangeHistory");

            migrationBuilder.RenameColumn(
                name: "CurrentRoomNumber",
                table: "EquipmentMovementHistory",
                newName: "RoomNumber");

            migrationBuilder.CreateTable(
                name: "EquipmentFinanciallyResponsiblePersonChangeHistory",
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
                    table.PrimaryKey("PK_EquipmentFinanciallyResponsiblePersonChangeHistory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentFinanciallyResponsiblePersonChangeHistory");

            migrationBuilder.RenameColumn(
                name: "RoomNumber",
                table: "EquipmentMovementHistory",
                newName: "CurrentRoomNumber");

            migrationBuilder.CreateTable(
                name: "FinanciallyResponsiblePersonChangeHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChangeTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CurrentFinanciallyResponsiblePersonId = table.Column<int>(type: "integer", nullable: false),
                    PreviousFinanciallyResponsiblePersonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanciallyResponsiblePersonChangeHistory", x => x.Id);
                });
        }
    }
}
