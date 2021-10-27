using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AddSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(maxLength: 30, nullable: false),
                    CourseId = table.Column<long>(nullable: false),
                    SemesterId = table.Column<long>(nullable: false),
                    SeatAvailable = table.Column<int>(nullable: false),
                    SeatLimit = table.Column<int>(nullable: false),
                    SeatUsed = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(maxLength: 500, nullable: true),
                    MidtermStart = table.Column<TimeSpan>(nullable: true),
                    MidtermEnd = table.Column<TimeSpan>(nullable: true),
                    MidtermDate = table.Column<DateTime>(nullable: true),
                    MidtermRoomId = table.Column<long>(nullable: true),
                    FinalStart = table.Column<TimeSpan>(nullable: true),
                    FinalEnd = table.Column<TimeSpan>(nullable: true),
                    FinalDate = table.Column<DateTime>(nullable: true),
                    FinalRoomId = table.Column<long>(nullable: true),
                    OpenedAt = table.Column<DateTime>(nullable: false),
                    ClosedAt = table.Column<DateTime>(nullable: true),
                    IsSpecialCase = table.Column<bool>(nullable: false),
                    IsClosed = table.Column<bool>(nullable: false),
                    IsEvening = table.Column<bool>(nullable: false),
                    IsParent = table.Column<bool>(nullable: false),
                    ParentSectionId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sections_Rooms_FinalRoomId",
                        column: x => x.FinalRoomId,
                        principalSchema: "master",
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sections_Rooms_MidtermRoomId",
                        column: x => x.MidtermRoomId,
                        principalSchema: "master",
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sections_Sections_ParentSectionId",
                        column: x => x.ParentSectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sections_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalSchema: "master",
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SectionDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SectionId = table.Column<long>(nullable: false),
                    TeachingTypeId = table.Column<long>(nullable: false),
                    RoomId = table.Column<long>(nullable: true),
                    Day = table.Column<int>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    InstructorIds = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionDetails_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "master",
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectionDetails_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectionDetails_TeachingTypes_TeachingTypeId",
                        column: x => x.TeachingTypeId,
                        principalSchema: "master",
                        principalTable: "TeachingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructorSections",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SectionDetailId = table.Column<long>(nullable: false),
                    InstructorId = table.Column<long>(nullable: false),
                    StartedAt = table.Column<DateTime>(nullable: false),
                    EndedAt = table.Column<DateTime>(nullable: false),
                    Hours = table.Column<decimal>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructorSections_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstructorSections_SectionDetails_SectionDetailId",
                        column: x => x.SectionDetailId,
                        principalTable: "SectionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstructorSections_InstructorId",
                table: "InstructorSections",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorSections_SectionDetailId",
                table: "InstructorSections",
                column: "SectionDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionDetails_RoomId",
                table: "SectionDetails",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionDetails_SectionId",
                table: "SectionDetails",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionDetails_TeachingTypeId",
                table: "SectionDetails",
                column: "TeachingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CourseId",
                table: "Sections",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_FinalRoomId",
                table: "Sections",
                column: "FinalRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_MidtermRoomId",
                table: "Sections",
                column: "MidtermRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ParentSectionId",
                table: "Sections",
                column: "ParentSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_SemesterId",
                table: "Sections",
                column: "SemesterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstructorSections");

            migrationBuilder.DropTable(
                name: "SectionDetails");

            migrationBuilder.DropTable(
                name: "Sections");
        }
    }
}
