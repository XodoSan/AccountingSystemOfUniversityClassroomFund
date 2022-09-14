using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ChangedWorkerEquipmentRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Worker_Equipment_EquipmentInventoryNumber",
                table: "Worker");

            migrationBuilder.DropIndex(
                name: "IX_Worker_EquipmentInventoryNumber",
                table: "Worker");

            migrationBuilder.DropColumn(
                name: "EquipmentInventoryNumber",
                table: "Worker");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentWorkerId",
                table: "Equipment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EquipmentWorkerId",
                table: "Equipment",
                column: "EquipmentWorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Worker_EquipmentWorkerId",
                table: "Equipment",
                column: "EquipmentWorkerId",
                principalTable: "Worker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Worker_EquipmentWorkerId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_EquipmentWorkerId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "EquipmentWorkerId",
                table: "Equipment");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentInventoryNumber",
                table: "Worker",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Worker_EquipmentInventoryNumber",
                table: "Worker",
                column: "EquipmentInventoryNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_Equipment_EquipmentInventoryNumber",
                table: "Worker",
                column: "EquipmentInventoryNumber",
                principalTable: "Equipment",
                principalColumn: "InventoryNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
