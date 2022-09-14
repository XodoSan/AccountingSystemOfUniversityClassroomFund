using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateEquipmentRoomNumberFieldName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Room_RoomNumber",
                table: "Equipment");

            migrationBuilder.RenameColumn(
                name: "RoomNumber",
                table: "Equipment",
                newName: "EquipmentRoomNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Equipment_RoomNumber",
                table: "Equipment",
                newName: "IX_Equipment_EquipmentRoomNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Room_EquipmentRoomNumber",
                table: "Equipment",
                column: "EquipmentRoomNumber",
                principalTable: "Room",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Room_EquipmentRoomNumber",
                table: "Equipment");

            migrationBuilder.RenameColumn(
                name: "EquipmentRoomNumber",
                table: "Equipment",
                newName: "RoomNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Equipment_EquipmentRoomNumber",
                table: "Equipment",
                newName: "IX_Equipment_RoomNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Room_RoomNumber",
                table: "Equipment",
                column: "RoomNumber",
                principalTable: "Room",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
