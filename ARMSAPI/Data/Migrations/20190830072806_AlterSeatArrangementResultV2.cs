using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AlterSeatArrangementResultV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_ExaminationRoom_Rooms_AUroomAPI.Models.DataModels.ExaminationRoom_RoomId",
            //     schema: "master",
            //     table: "ExaminationRoom");

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

            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "SeatArrangementResults");

            migrationBuilder.DropColumn(
                name: "CourseNameEn",
                table: "SeatArrangementResults");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "SeatArrangementResults");

            migrationBuilder.DropColumn(
                name: "ExamDate",
                table: "SeatArrangementResults");

            migrationBuilder.DropColumn(
                name: "FirstNameEn",
                table: "SeatArrangementResults");

            migrationBuilder.DropColumn(
                name: "LastNameEn",
                table: "SeatArrangementResults");

            migrationBuilder.DropColumn(
                name: "RoomName",
                table: "SeatArrangementResults");

            migrationBuilder.DropColumn(
                name: "SectionNumber",
                table: "SeatArrangementResults");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "SeatArrangementResults");

            migrationBuilder.DropColumn(
                name: "StudentCode",
                table: "SeatArrangementResults");

            migrationBuilder.AddColumn<long>(
                name: "CourseId",
                table: "SeatArrangementResults",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ExaminationSlotId",
                table: "SeatArrangementResults",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "RoomId",
                table: "SeatArrangementResults",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SectionId",
                table: "SeatArrangementResults",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "StudentId",
                table: "SeatArrangementResults",
                nullable: false,
                defaultValue: 0L);

            // migrationBuilder.CreateIndex(
            //     name: "IX_ExaminationRoom_RoomId",
            //     schema: "master",
            //     table: "ExaminationRoom",
            //     column: "RoomId",
            //     unique: false);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_ExaminationRoom_Rooms_RoomId",
            //     schema: "master",
            //     table: "ExaminationRoom",
            //     column: "RoomId",
            //     principalSchema: "master",
            //     principalTable: "Rooms",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_ExaminationRoom_Rooms_RoomId",
            //     schema: "master",
            //     table: "ExaminationRoom");

            // migrationBuilder.DropIndex(
            //     name: "IX_ExaminationRoom_RoomId",
            //     schema: "master",
            //     table: "ExaminationRoom");

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

            migrationBuilder.AddColumn<int>(
                name: "ARMSAPI.Models.DataModels.ExaminationRoom",
                schema: "master",
                table: "ExaminationRoom",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "SeatArrangementResults",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseNameEn",
                table: "SeatArrangementResults",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "SeatArrangementResults",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExamDate",
                table: "SeatArrangementResults",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstNameEn",
                table: "SeatArrangementResults",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastNameEn",
                table: "SeatArrangementResults",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomName",
                table: "SeatArrangementResults",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SectionNumber",
                table: "SeatArrangementResults",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "SeatArrangementResults",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "StudentCode",
                table: "SeatArrangementResults",
                nullable: true);

            // migrationBuilder.AddUniqueConstraint(
            //     name: "AK_Rooms_TempId_TempId1",
            //     schema: "master",
            //     table: "Rooms",
            //     columns: new[] { "TempId", "TempId1" });

            // migrationBuilder.CreateIndex(
            //     name: "IX_ExaminationRoom_RoomId",
            //     schema: "master",
            //     table: "ExaminationRoom",
            //     column: "RoomId");

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
