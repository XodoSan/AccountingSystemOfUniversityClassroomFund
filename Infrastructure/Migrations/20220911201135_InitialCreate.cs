using System;
using Domain.Constants;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:purpose", "educational,no_educational")
                .Annotation("Npgsql:Enum:room_type", "lecture,for_partical_training,gym,canteen");

            migrationBuilder.CreateTable(
                name: "EquipmentCategory",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    EquipmentAmount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentCategory", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentMovementHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MovementTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EquipmentInventoryNumber = table.Column<int>(type: "integer", nullable: false),
                    PreviousRoomNumber = table.Column<int>(type: "integer", nullable: false),
                    CurrentRoomNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentMovementHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinanciallyResponsiblePersonChangeHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChangeTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PreviousFinanciallyResponsiblePersonId = table.Column<int>(type: "integer", nullable: false),
                    CurrentFinanciallyResponsiblePersonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanciallyResponsiblePersonChangeHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UniversityBuilding",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Adress = table.Column<string>(type: "text", nullable: false),
                    StoreysNumber = table.Column<int>(type: "integer", nullable: false),
                    FoundationYear = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityBuilding", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Subdivision",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    UniversityName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subdivision", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Subdivision_UniversityBuilding_UniversityName",
                        column: x => x.UniversityName,
                        principalTable: "UniversityBuilding",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Number = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Purpose = table.Column<Purpose>(type: "purpose", nullable: false),
                    RoomType = table.Column<RoomType>(type: "room_type", nullable: false),
                    Area = table.Column<int>(type: "integer", nullable: false),
                    FloorPlan = table.Column<string>(type: "text", nullable: false),
                    OwnerName = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Floor = table.Column<int>(type: "integer", nullable: false),
                    SubdivisionName = table.Column<string>(type: "text", nullable: false),
                    UniversityName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Room_Subdivision_OwnerName",
                        column: x => x.OwnerName,
                        principalTable: "Subdivision",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Room_Subdivision_SubdivisionName",
                        column: x => x.SubdivisionName,
                        principalTable: "Subdivision",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Room_UniversityBuilding_UniversityName",
                        column: x => x.UniversityName,
                        principalTable: "UniversityBuilding",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    InventoryNumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SerialNumber = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CommissioningDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    EquipmentCategoryName = table.Column<string>(type: "text", nullable: false),
                    RoomNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.InventoryNumber);
                    table.ForeignKey(
                        name: "FK_Equipment_EquipmentCategory_CategoryName",
                        column: x => x.CategoryName,
                        principalTable: "EquipmentCategory",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipment_EquipmentCategory_EquipmentCategoryName",
                        column: x => x.EquipmentCategoryName,
                        principalTable: "EquipmentCategory",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipment_Room_RoomNumber",
                        column: x => x.RoomNumber,
                        principalTable: "Room",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Instruction = table.Column<string>(type: "text", nullable: false),
                    Purpose = table.Column<Purpose>(type: "purpose", nullable: false),
                    EquipmentInventoryNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usage_Equipment_EquipmentInventoryNumber",
                        column: x => x.EquipmentInventoryNumber,
                        principalTable: "Equipment",
                        principalColumn: "InventoryNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    SubdivisionName = table.Column<string>(type: "text", nullable: false),
                    EquipmentInventoryNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Worker_Equipment_EquipmentInventoryNumber",
                        column: x => x.EquipmentInventoryNumber,
                        principalTable: "Equipment",
                        principalColumn: "InventoryNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Worker_Subdivision_SubdivisionName",
                        column: x => x.SubdivisionName,
                        principalTable: "Subdivision",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_CategoryName",
                table: "Equipment",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EquipmentCategoryName",
                table: "Equipment",
                column: "EquipmentCategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_RoomNumber",
                table: "Equipment",
                column: "RoomNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Room_OwnerName",
                table: "Room",
                column: "OwnerName");

            migrationBuilder.CreateIndex(
                name: "IX_Room_SubdivisionName",
                table: "Room",
                column: "SubdivisionName");

            migrationBuilder.CreateIndex(
                name: "IX_Room_UniversityName",
                table: "Room",
                column: "UniversityName");

            migrationBuilder.CreateIndex(
                name: "IX_Subdivision_UniversityName",
                table: "Subdivision",
                column: "UniversityName");

            migrationBuilder.CreateIndex(
                name: "IX_Usage_EquipmentInventoryNumber",
                table: "Usage",
                column: "EquipmentInventoryNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Worker_EquipmentInventoryNumber",
                table: "Worker",
                column: "EquipmentInventoryNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Worker_SubdivisionName",
                table: "Worker",
                column: "SubdivisionName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentMovementHistory");

            migrationBuilder.DropTable(
                name: "FinanciallyResponsiblePersonChangeHistory");

            migrationBuilder.DropTable(
                name: "Usage");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "EquipmentCategory");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Subdivision");

            migrationBuilder.DropTable(
                name: "UniversityBuilding");
        }
    }
}
