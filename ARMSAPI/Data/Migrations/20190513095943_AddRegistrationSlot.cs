using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AddRegistrationSlot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slots",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    SemesterId = table.Column<long>(nullable: false),
                    Round = table.Column<int>(nullable: false),
                    IsSpecialSlot = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: true),
                    StartedAt = table.Column<DateTime>(nullable: false),
                    EndedAt = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slots_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalSchema: "master",
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationSlots",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SlotId = table.Column<long>(nullable: false),
                    StudentId = table.Column<long>(nullable: true),
                    AcademicProgramId = table.Column<long>(nullable: true),
                    FacultyId = table.Column<long>(nullable: true),
                    DepartmentId = table.Column<long>(nullable: true),
                    BatchCodeStart = table.Column<int>(nullable: false),
                    BatchCodeEnd = table.Column<int>(nullable: false),
                    LastDigitStart = table.Column<int>(nullable: false),
                    LastDigitEnd = table.Column<int>(nullable: false),
                    IsGraduating = table.Column<bool>(nullable: false),
                    IsAthlete = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrationSlots_AcademicPrograms_AcademicProgramId",
                        column: x => x.AcademicProgramId,
                        principalSchema: "master",
                        principalTable: "AcademicPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrationSlots_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "master",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrationSlots_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "master",
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrationSlots_Slots_SlotId",
                        column: x => x.SlotId,
                        principalTable: "Slots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrationSlots_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "student",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationSlots_AcademicProgramId",
                table: "RegistrationSlots",
                column: "AcademicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationSlots_DepartmentId",
                table: "RegistrationSlots",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationSlots_FacultyId",
                table: "RegistrationSlots",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationSlots_SlotId",
                table: "RegistrationSlots",
                column: "SlotId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationSlots_StudentId",
                table: "RegistrationSlots",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Slots_SemesterId",
                table: "Slots",
                column: "SemesterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrationSlots");

            migrationBuilder.DropTable(
                name: "Slots");
        }
    }
}
