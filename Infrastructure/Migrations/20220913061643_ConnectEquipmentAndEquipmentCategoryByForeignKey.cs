using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ConnectEquipmentAndEquipmentCategoryByForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_EquipmentCategory_CategoryName",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_CategoryName",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Equipment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Equipment",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_CategoryName",
                table: "Equipment",
                column: "CategoryName");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_EquipmentCategory_CategoryName",
                table: "Equipment",
                column: "CategoryName",
                principalTable: "EquipmentCategory",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
