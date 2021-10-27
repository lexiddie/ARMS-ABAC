using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AddRegistrationResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistrationResults",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Channel = table.Column<string>(maxLength: 5, nullable: true),
                    StudentId = table.Column<long>(nullable: false),
                    SemesterId = table.Column<long>(nullable: false),
                    CourseId = table.Column<long>(nullable: false),
                    SectionId = table.Column<long>(nullable: false),
                    IsLock = table.Column<bool>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrationResults_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrationResults_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrationResults_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalSchema: "master",
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrationResults_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "student",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationResults_CourseId",
                table: "RegistrationResults",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationResults_SectionId",
                table: "RegistrationResults",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationResults_SemesterId",
                table: "RegistrationResults",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationResults_StudentId",
                table: "RegistrationResults",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrationResults");
        }
    }
}
