using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AddIsAuto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExaminationRoom_RoomId",
                schema: "master",
                table: "ExaminationRoom");

            migrationBuilder.AddColumn<bool>(
                name: "IsAuto",
                schema: "master",
                table: "ExaminationRoom",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAuto",
                table: "SeatArrangementResults",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationRoom_RoomId",
                schema: "master",
                table: "ExaminationRoom",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExaminationRoom_RoomId",
                schema: "master",
                table: "ExaminationRoom");

            migrationBuilder.DropColumn(
                name: "IsAuto",
                schema: "master",
                table: "ExaminationRoom");

            migrationBuilder.DropColumn(
                name: "IsAuto",
                table: "SeatArrangementResults");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationRoom_RoomId",
                schema: "master",
                table: "ExaminationRoom",
                column: "RoomId",
                unique: true);
        }
    }
}
