using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AddSeatArrangementConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_ExaminationRoom_Rooms_AUroomAPI.Models.DataModels.ExaminationRoom_RoomId",
            //     schema: "master",
            //     table: "ExaminationRoom");

            // migrationBuilder.DropTable(
            //     name: "SectionExaminationSlot",
            //     schema: "master");

            // migrationBuilder.DropUniqueConstraint(
            //     name: "AK_Rooms_TempId_TempId1",
            //     schema: "master",
            //     table: "Rooms");

            // migrationBuilder.DropIndex(
            //     name: "IX_ExaminationRoom_RoomId",
            //     schema: "master",
            //     table: "ExaminationRoom");

            // migrationBuilder.DropColumn(
            //     name: "TempId",
            //     schema: "master",
            //     table: "Rooms");

            // migrationBuilder.DropColumn(
            //     name: "TempId1",
            //     schema: "master",
            //     table: "Rooms");

            // migrationBuilder.DropColumn(
            //     name: "ARMSAPI.Models.DataModels.ExaminationRoom",
            //     schema: "master",
            //     table: "ExaminationRoom");

            // migrationBuilder.DropColumn(
            //     name: "CourseCode",
            //     table: "SeatArrangementResults");

            // migrationBuilder.DropColumn(
            //     name: "CourseNameEn",
            //     table: "SeatArrangementResults");

            // migrationBuilder.DropColumn(
            //     name: "EndTime",
            //     table: "SeatArrangementResults");

            // migrationBuilder.DropColumn(
            //     name: "ExamDate",
            //     table: "SeatArrangementResults");

            // migrationBuilder.DropColumn(
            //     name: "FirstNameEn",
            //     table: "SeatArrangementResults");

            // migrationBuilder.DropColumn(
            //     name: "LastNameEn",
            //     table: "SeatArrangementResults");

            // migrationBuilder.DropColumn(
            //     name: "RoomName",
            //     table: "SeatArrangementResults");

            // migrationBuilder.DropColumn(
            //     name: "SectionNumber",
            //     table: "SeatArrangementResults");

            // migrationBuilder.DropColumn(
            //     name: "StartTime",
            //     table: "SeatArrangementResults");

            // migrationBuilder.DropColumn(
            //     name: "StudentCode",
            //     table: "SeatArrangementResults");

            // migrationBuilder.AddColumn<long>(
            //     name: "ExaminationTypeId",
            //     schema: "master",
            //     table: "ExaminationSlot",
            //     nullable: false,
            //     defaultValue: 0L);

            // migrationBuilder.AddColumn<long>(
            //     name: "CourseId",
            //     table: "SeatArrangementResults",
            //     nullable: false,
            //     defaultValue: 0L);

            // migrationBuilder.AddColumn<long>(
            //     name: "ExaminationSlotId",
            //     table: "SeatArrangementResults",
            //     nullable: false,
            //     defaultValue: 0L);

            // migrationBuilder.AddColumn<long>(
            //     name: "RoomId",
            //     table: "SeatArrangementResults",
            //     nullable: false,
            //     defaultValue: 0L);

            // migrationBuilder.AddColumn<long>(
            //     name: "SectionId",
            //     table: "SeatArrangementResults",
            //     nullable: false,
            //     defaultValue: 0L);

            // migrationBuilder.AddColumn<long>(
            //     name: "StudentId",
            //     table: "SeatArrangementResults",
            //     nullable: false,
            //     defaultValue: 0L);

            // migrationBuilder.CreateTable(
            //     name: "CourseExaminationSlot",
            //     schema: "master",
            //     columns: table => new
            //     {
            //         Id = table.Column<long>(nullable: false)
            //             .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //         CreatedAt = table.Column<DateTime>(nullable: false),
            //         CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
            //         UpdatedAt = table.Column<DateTime>(nullable: false),
            //         UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
            //         IsActive = table.Column<bool>(nullable: false),
            //         CourseId = table.Column<long>(nullable: false),
            //         ExaminationSlotId = table.Column<long>(nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_CourseExaminationSlot", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_CourseExaminationSlot_Courses_CourseId",
            //             column: x => x.CourseId,
            //             principalTable: "Courses",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_CourseExaminationSlot_ExaminationSlot_ExaminationSlotId",
            //             column: x => x.ExaminationSlotId,
            //             principalSchema: "master",
            //             principalTable: "ExaminationSlot",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });

            // migrationBuilder.CreateIndex(
            //     name: "IX_ExaminationSlot_ExaminationTypeId",
            //     schema: "master",
            //     table: "ExaminationSlot",
            //     column: "ExaminationTypeId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_ExaminationRoom_RoomId",
            //     schema: "master",
            //     table: "ExaminationRoom",
            //     column: "RoomId",
            //     unique: true);

            // migrationBuilder.CreateIndex(
            //     name: "IX_SeatArrangementResults_CourseId",
            //     table: "SeatArrangementResults",
            //     column: "CourseId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_SeatArrangementResults_RoomId",
            //     table: "SeatArrangementResults",
            //     column: "RoomId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_SeatArrangementResults_SectionId",
            //     table: "SeatArrangementResults",
            //     column: "SectionId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_SeatArrangementResults_StudentId",
            //     table: "SeatArrangementResults",
            //     column: "StudentId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_CourseExaminationSlot_CourseId",
            //     schema: "master",
            //     table: "CourseExaminationSlot",
            //     column: "CourseId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_CourseExaminationSlot_ExaminationSlotId",
            //     schema: "master",
            //     table: "CourseExaminationSlot",
            //     column: "ExaminationSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_SeatArrangementResults_Courses_CourseId",
                table: "SeatArrangementResults",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeatArrangementResults_Rooms_RoomId",
                table: "SeatArrangementResults",
                column: "RoomId",
                principalSchema: "master",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeatArrangementResults_Sections_SectionId",
                table: "SeatArrangementResults",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeatArrangementResults_Students_StudentId",
                table: "SeatArrangementResults",
                column: "StudentId",
                principalSchema: "student",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_ExaminationRoom_Rooms_RoomId",
            //     schema: "master",
            //     table: "ExaminationRoom",
            //     column: "RoomId",
            //     principalSchema: "master",
            //     principalTable: "Rooms",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_ExaminationSlot_ExaminationTypes_ExaminationTypeId",
            //     schema: "master",
            //     table: "ExaminationSlot",
            //     column: "ExaminationTypeId",
            //     principalSchema: "master",
            //     principalTable: "ExaminationTypes",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeatArrangementResults_Courses_CourseId",
                table: "SeatArrangementResults");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatArrangementResults_Rooms_RoomId",
                table: "SeatArrangementResults");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatArrangementResults_Sections_SectionId",
                table: "SeatArrangementResults");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatArrangementResults_Students_StudentId",
                table: "SeatArrangementResults");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_ExaminationRoom_Rooms_RoomId",
            //     schema: "master",
            //     table: "ExaminationRoom");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_ExaminationSlot_ExaminationTypes_ExaminationTypeId",
            //     schema: "master",
            //     table: "ExaminationSlot");

            // migrationBuilder.DropTable(
            //     name: "CourseExaminationSlot",
            //     schema: "master");

            // migrationBuilder.DropIndex(
            //     name: "IX_ExaminationSlot_ExaminationTypeId",
            //     schema: "master",
            //     table: "ExaminationSlot");

            // migrationBuilder.DropIndex(
            //     name: "IX_ExaminationRoom_RoomId",
            //     schema: "master",
            //     table: "ExaminationRoom");

            migrationBuilder.DropIndex(
                name: "IX_SeatArrangementResults_CourseId",
                table: "SeatArrangementResults");

            migrationBuilder.DropIndex(
                name: "IX_SeatArrangementResults_RoomId",
                table: "SeatArrangementResults");

            migrationBuilder.DropIndex(
                name: "IX_SeatArrangementResults_SectionId",
                table: "SeatArrangementResults");

            migrationBuilder.DropIndex(
                name: "IX_SeatArrangementResults_StudentId",
                table: "SeatArrangementResults");

            // migrationBuilder.DropColumn(
            //     name: "ExaminationTypeId",
            //     schema: "master",
            //     table: "ExaminationSlot");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "SeatArrangementResults");

            migrationBuilder.DropColumn(
                name: "ExaminationSlotId",
                table: "SeatArrangementResults");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "SeatArrangementResults");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "SeatArrangementResults");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "SeatArrangementResults");

            // migrationBuilder.AddColumn<int>(
            //     name: "TempId",
            //     schema: "master",
            //     table: "Rooms",
            //     nullable: false,
            //     defaultValue: 0);

            // migrationBuilder.AddColumn<long>(
            //     name: "TempId1",
            //     schema: "master",
            //     table: "Rooms",
            //     nullable: false,
            //     defaultValue: 0L);

            // migrationBuilder.AddColumn<int>(
            //     name: "ARMSAPI.Models.DataModels.ExaminationRoom",
            //     schema: "master",
            //     table: "ExaminationRoom",
            //     nullable: true);

            // migrationBuilder.AddColumn<string>(
            //     name: "CourseCode",
            //     table: "SeatArrangementResults",
            //     nullable: true);

            // migrationBuilder.AddColumn<string>(
            //     name: "CourseNameEn",
            //     table: "SeatArrangementResults",
            //     nullable: true);

            // migrationBuilder.AddColumn<TimeSpan>(
            //     name: "EndTime",
            //     table: "SeatArrangementResults",
            //     nullable: false,
            //     defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            // migrationBuilder.AddColumn<DateTime>(
            //     name: "ExamDate",
            //     table: "SeatArrangementResults",
            //     nullable: false,
            //     defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            // migrationBuilder.AddColumn<string>(
            //     name: "FirstNameEn",
            //     table: "SeatArrangementResults",
            //     nullable: true);

            // migrationBuilder.AddColumn<string>(
            //     name: "LastNameEn",
            //     table: "SeatArrangementResults",
            //     nullable: true);

            // migrationBuilder.AddColumn<string>(
            //     name: "RoomName",
            //     table: "SeatArrangementResults",
            //     nullable: true);

            // migrationBuilder.AddColumn<string>(
            //     name: "SectionNumber",
            //     table: "SeatArrangementResults",
            //     nullable: true);

            // migrationBuilder.AddColumn<TimeSpan>(
            //     name: "StartTime",
            //     table: "SeatArrangementResults",
            //     nullable: false,
            //     defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            // migrationBuilder.AddColumn<string>(
            //     name: "StudentCode",
            //     table: "SeatArrangementResults",
            //     nullable: true);

            // migrationBuilder.AddUniqueConstraint(
            //     name: "AK_Rooms_TempId_TempId1",
            //     schema: "master",
            //     table: "Rooms",
            //     columns: new[] { "TempId", "TempId1" });

            // migrationBuilder.CreateTable(
            //     name: "SectionExaminationSlot",
            //     schema: "master",
            //     columns: table => new
            //     {
            //         Id = table.Column<long>(nullable: false)
            //             .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //         CreatedAt = table.Column<DateTime>(nullable: false),
            //         CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
            //         ExaminationSlotId = table.Column<long>(nullable: false),
            //         ExaminationTypeId = table.Column<long>(nullable: false),
            //         IsActive = table.Column<bool>(nullable: false),
            //         SectionId = table.Column<long>(nullable: false),
            //         UpdatedAt = table.Column<DateTime>(nullable: false),
            //         UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_SectionExaminationSlot", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_SectionExaminationSlot_ExaminationSlot_ExaminationSlotId",
            //             column: x => x.ExaminationSlotId,
            //             principalSchema: "master",
            //             principalTable: "ExaminationSlot",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_SectionExaminationSlot_ExaminationTypes_ExaminationTypeId",
            //             column: x => x.ExaminationTypeId,
            //             principalSchema: "master",
            //             principalTable: "ExaminationTypes",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_SectionExaminationSlot_Sections_SectionId",
            //             column: x => x.SectionId,
            //             principalTable: "Sections",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });

            // migrationBuilder.CreateIndex(
            //     name: "IX_ExaminationRoom_RoomId",
            //     schema: "master",
            //     table: "ExaminationRoom",
            //     column: "RoomId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_SectionExaminationSlot_ExaminationSlotId",
            //     schema: "master",
            //     table: "SectionExaminationSlot",
            //     column: "ExaminationSlotId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_SectionExaminationSlot_ExaminationTypeId",
            //     schema: "master",
            //     table: "SectionExaminationSlot",
            //     column: "ExaminationTypeId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_SectionExaminationSlot_SectionId",
            //     schema: "master",
            //     table: "SectionExaminationSlot",
            //     column: "SectionId");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_ExaminationRoom_Rooms_AUroomAPI.Models.DataModels.ExaminationRoom_RoomId",
            //     schema: "master",
            //     table: "ExaminationRoom",
            //     columns: new[] { "ARMSAPI.Models.DataModels.ExaminationRoom", "RoomId" },
            //     principalSchema: "master",
            //     principalTable: "Rooms",
            //     principalColumns: new[] { "TempId", "TempId1" },
            //     onDelete: ReferentialAction.Cascade);
        }
    }
}
