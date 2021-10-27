using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AlterSeatArrangement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExaminationRoom_RoomId",
                schema: "master",
                table: "ExaminationRoom");

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "SeatArrangementResult",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseNameEn",
                table: "SeatArrangementResult",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationRoom_RoomId",
                schema: "master",
                table: "ExaminationRoom",
                column: "RoomId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExaminationRoom_RoomId",
                schema: "master",
                table: "ExaminationRoom");

            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "SeatArrangementResult");

            migrationBuilder.DropColumn(
                name: "CourseNameEn",
                table: "SeatArrangementResult");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationRoom_RoomId",
                schema: "master",
                table: "ExaminationRoom",
                column: "RoomId");
        }
    }
}
