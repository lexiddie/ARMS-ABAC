using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AlterTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Rooms_FinalRoomId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Rooms_MidtermRoomId",
                table: "Sections");

            migrationBuilder.DropTable(
                name: "ExaminationPeriods");

            migrationBuilder.DropIndex(
                name: "IX_Sections_MidtermRoomId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "FinalDate",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "FinalEnd",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "FinalStart",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "MidtermDate",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "MidtermEnd",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "MidtermStart",
                table: "Sections");

            migrationBuilder.RenameColumn(
                name: "MidtermRoomId",
                table: "Sections",
                newName: "QuizIIExaminationSlotId");

            migrationBuilder.RenameColumn(
                name: "FinalRoomId",
                table: "Sections",
                newName: "QuizIExaminationSlotId");

            migrationBuilder.RenameIndex(
                name: "IX_Sections_FinalRoomId",
                table: "Sections",
                newName: "IX_Sections_QuizIExaminationSlotId");

            migrationBuilder.AddColumn<int>(
                name: "Rows",
                schema: "master",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "FinalExaminationSlotId",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MidtermExaminationSlotId",
                table: "Sections",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SeatArrangementResult",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    StudentCode = table.Column<string>(nullable: true),
                    FirstNameEn = table.Column<string>(nullable: true),
                    LastNameEn = table.Column<string>(nullable: true),
                    SectionNumber = table.Column<string>(nullable: true),
                    ExamDate = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    RoomName = table.Column<string>(nullable: true),
                    SeatPosition = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatArrangementResult", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExaminationSlot",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    SemesterId = table.Column<long>(nullable: false),
                    AcademicLevelId = table.Column<long>(nullable: false),
                    ExaminationTypeId = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    TimeStart = table.Column<TimeSpan>(nullable: false),
                    TimeEnd = table.Column<TimeSpan>(nullable: false),
                    CourseId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaminationSlot_AcademicLevels_AcademicLevelId",
                        column: x => x.AcademicLevelId,
                        principalSchema: "master",
                        principalTable: "AcademicLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExaminationSlot_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExaminationSlot_ExaminationTypes_ExaminationTypeId",
                        column: x => x.ExaminationTypeId,
                        principalSchema: "master",
                        principalTable: "ExaminationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExaminationSlot_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalSchema: "master",
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExaminationRoom",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    SectionId = table.Column<long>(nullable: false),
                    CourseCode = table.Column<string>(nullable: true),
                    ExaminationSlotId = table.Column<long>(nullable: false),
                    RoomId = table.Column<long>(nullable: false),
                    StartStudentCode = table.Column<string>(nullable: true),
                    EndStudentCode = table.Column<string>(nullable: true),
                    TotalSeatUsed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaminationRoom_ExaminationSlot_ExaminationSlotId",
                        column: x => x.ExaminationSlotId,
                        principalSchema: "master",
                        principalTable: "ExaminationSlot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExaminationRoom_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "master",
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExaminationRoom_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sections_FinalExaminationSlotId",
                table: "Sections",
                column: "FinalExaminationSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_MidtermExaminationSlotId",
                table: "Sections",
                column: "MidtermExaminationSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationRoom_ExaminationSlotId",
                schema: "master",
                table: "ExaminationRoom",
                column: "ExaminationSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationRoom_RoomId",
                schema: "master",
                table: "ExaminationRoom",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationRoom_SectionId",
                schema: "master",
                table: "ExaminationRoom",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationSlot_AcademicLevelId",
                schema: "master",
                table: "ExaminationSlot",
                column: "AcademicLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationSlot_CourseId",
                schema: "master",
                table: "ExaminationSlot",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationSlot_ExaminationTypeId",
                schema: "master",
                table: "ExaminationSlot",
                column: "ExaminationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationSlot_SemesterId",
                schema: "master",
                table: "ExaminationSlot",
                column: "SemesterId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "SeatArrangementResult");

            migrationBuilder.DropTable(
                name: "ExaminationRoom",
                schema: "master");

            migrationBuilder.DropTable(
                name: "ExaminationSlot",
                schema: "master");

            migrationBuilder.DropIndex(
                name: "IX_Sections_FinalExaminationSlotId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_MidtermExaminationSlotId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Rows",
                schema: "master",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "FinalExaminationSlotId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "MidtermExaminationSlotId",
                table: "Sections");

            migrationBuilder.RenameColumn(
                name: "QuizIIExaminationSlotId",
                table: "Sections",
                newName: "MidtermRoomId");

            migrationBuilder.RenameColumn(
                name: "QuizIExaminationSlotId",
                table: "Sections",
                newName: "FinalRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Sections_QuizIExaminationSlotId",
                table: "Sections",
                newName: "IX_Sections_FinalRoomId");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinalDate",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "FinalEnd",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "FinalStart",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MidtermDate",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "MidtermEnd",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "MidtermStart",
                table: "Sections",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExaminationPeriods",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    FinalDate = table.Column<DateTime>(nullable: false),
                    FinalEnd = table.Column<TimeSpan>(nullable: false),
                    FinalStart = table.Column<TimeSpan>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsEvening = table.Column<bool>(nullable: false),
                    MidtermDate = table.Column<DateTime>(nullable: false),
                    MidtermEnd = table.Column<TimeSpan>(nullable: false),
                    MidtermStart = table.Column<TimeSpan>(nullable: false),
                    SemesterId = table.Column<long>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaminationPeriods_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExaminationPeriods_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalSchema: "master",
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sections_MidtermRoomId",
                table: "Sections",
                column: "MidtermRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationPeriods_CourseId",
                table: "ExaminationPeriods",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationPeriods_SemesterId",
                table: "ExaminationPeriods",
                column: "SemesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Rooms_FinalRoomId",
                table: "Sections",
                column: "FinalRoomId",
                principalSchema: "master",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Rooms_MidtermRoomId",
                table: "Sections",
                column: "MidtermRoomId",
                principalSchema: "master",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
