using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AddFKConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SeatArrangementResults_ExaminationSlotId",
                table: "SeatArrangementResults",
                column: "ExaminationSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_SeatArrangementResults_ExaminationSlot_ExaminationSlotId",
                table: "SeatArrangementResults",
                column: "ExaminationSlotId",
                principalSchema: "master",
                principalTable: "ExaminationSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeatArrangementResults_ExaminationSlot_ExaminationSlotId",
                table: "SeatArrangementResults");

            migrationBuilder.DropIndex(
                name: "IX_SeatArrangementResults_ExaminationSlotId",
                table: "SeatArrangementResults");
        }
    }
}
