using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AddSectionExaminationSlot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_ExaminationSlot_FinalExaminationSlotId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_ExaminationSlot_MidtermExaminationSlotId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_ExaminationSlot_QuizIExaminationSlotId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_ExaminationSlot_ExaminationTypes_ExaminationTypeId",
                schema: "master",
                table: "ExaminationSlot");

            migrationBuilder.DropIndex(
                name: "IX_ExaminationSlot_ExaminationTypeId",
                schema: "master",
                table: "ExaminationSlot");

            migrationBuilder.DropIndex(
                name: "IX_Sections_FinalExaminationSlotId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_MidtermExaminationSlotId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_QuizIExaminationSlotId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "ExaminationTypeId",
                schema: "master",
                table: "ExaminationSlot");

            migrationBuilder.DropColumn(
                name: "FinalExaminationSlotId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "MidtermExaminationSlotId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "QuizIExaminationSlotId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "QuizIIExaminationSlotId",
                table: "Sections");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ExaminationTypeId",
                schema: "master",
                table: "ExaminationSlot",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "FinalExaminationSlotId",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MidtermExaminationSlotId",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "QuizIExaminationSlotId",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "QuizIIExaminationSlotId",
                table: "Sections",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationSlot_ExaminationTypeId",
                schema: "master",
                table: "ExaminationSlot",
                column: "ExaminationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_FinalExaminationSlotId",
                table: "Sections",
                column: "FinalExaminationSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_MidtermExaminationSlotId",
                table: "Sections",
                column: "MidtermExaminationSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_QuizIExaminationSlotId",
                table: "Sections",
                column: "QuizIExaminationSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_ExaminationSlot_FinalExaminationSlotId",
                table: "Sections",
                column: "FinalExaminationSlotId",
                principalSchema: "master",
                principalTable: "ExaminationSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_ExaminationSlot_MidtermExaminationSlotId",
                table: "Sections",
                column: "MidtermExaminationSlotId",
                principalSchema: "master",
                principalTable: "ExaminationSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_ExaminationSlot_QuizIExaminationSlotId",
                table: "Sections",
                column: "QuizIExaminationSlotId",
                principalSchema: "master",
                principalTable: "ExaminationSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExaminationSlot_ExaminationTypes_ExaminationTypeId",
                schema: "master",
                table: "ExaminationSlot",
                column: "ExaminationTypeId",
                principalSchema: "master",
                principalTable: "ExaminationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
