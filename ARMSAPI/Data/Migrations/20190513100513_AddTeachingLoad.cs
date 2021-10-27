using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AddTeachingLoad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeachingLoads",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SemesterId = table.Column<long>(nullable: false),
                    InstructorId = table.Column<long>(nullable: false),
                    CourseId = table.Column<long>(nullable: false),
                    TotalSectionsCount = table.Column<int>(nullable: false),
                    TeachingTypeId = table.Column<long>(nullable: false),
                    Load = table.Column<decimal>(nullable: false),
                    IsExtraLoad = table.Column<bool>(nullable: false),
                    Remark = table.Column<string>(maxLength: 500, nullable: true),
                    IsUpdated = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachingLoads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeachingLoads_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeachingLoads_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeachingLoads_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalSchema: "master",
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeachingLoads_TeachingTypes_TeachingTypeId",
                        column: x => x.TeachingTypeId,
                        principalSchema: "master",
                        principalTable: "TeachingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeachingLoads_CourseId",
                table: "TeachingLoads",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingLoads_InstructorId",
                table: "TeachingLoads",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingLoads_SemesterId",
                table: "TeachingLoads",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingLoads_TeachingTypeId",
                table: "TeachingLoads",
                column: "TeachingTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeachingLoads");
        }
    }
}
