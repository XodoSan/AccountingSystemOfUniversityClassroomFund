using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UseNewTypeFloorPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FloorPlan",
                table: "Room");

            migrationBuilder.CreateTable(
                name: "RoomFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<byte[]>(type: "bytea", nullable: false),
                    CurrentRoomNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomFile_Room_CurrentRoomNumber",
                        column: x => x.CurrentRoomNumber,
                        principalTable: "Room",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomFile_CurrentRoomNumber",
                table: "RoomFile",
                column: "CurrentRoomNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomFile");

            migrationBuilder.AddColumn<string>(
                name: "FloorPlan",
                table: "Room",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
