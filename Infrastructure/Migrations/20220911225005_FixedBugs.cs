using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FixedBugs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Subdivision_OwnerName",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_OwnerName",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Room");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Room",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Room_OwnerName",
                table: "Room",
                column: "OwnerName");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Subdivision_OwnerName",
                table: "Room",
                column: "OwnerName",
                principalTable: "Subdivision",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
