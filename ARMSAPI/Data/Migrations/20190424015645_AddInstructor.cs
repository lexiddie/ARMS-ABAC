using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AddInstructor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TitleId = table.Column<long>(nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    FirstNameEn = table.Column<string>(maxLength: 100, nullable: true),
                    FirstNameTh = table.Column<string>(maxLength: 100, nullable: true),
                    LastNameEn = table.Column<string>(maxLength: 100, nullable: true),
                    LastNameTh = table.Column<string>(maxLength: 100, nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    NationalityId = table.Column<long>(nullable: false),
                    RaceId = table.Column<long>(nullable: false),
                    ReligionId = table.Column<long>(nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    CountryId = table.Column<long>(nullable: false),
                    CityId = table.Column<long>(nullable: true),
                    StateId = table.Column<long>(nullable: true),
                    ProvinceId = table.Column<long>(nullable: true),
                    DistrictId = table.Column<long>(nullable: true),
                    SubdistrictId = table.Column<long>(nullable: true),
                    ZipCode = table.Column<string>(maxLength: 20, nullable: true),
                    TelephoneNumber1 = table.Column<string>(maxLength: 20, nullable: true),
                    TelephoneNumber2 = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    PersonalEmail = table.Column<string>(maxLength: 100, nullable: true),
                    ProfileImageURL = table.Column<string>(maxLength: 2100, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "master",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructors_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "master",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructors_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "master",
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructors_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalSchema: "master",
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructors_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "master",
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructors_Races_RaceId",
                        column: x => x.RaceId,
                        principalSchema: "master",
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructors_Religions_ReligionId",
                        column: x => x.ReligionId,
                        principalSchema: "master",
                        principalTable: "Religions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructors_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "master",
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructors_Subdistricts_SubdistrictId",
                        column: x => x.SubdistrictId,
                        principalSchema: "master",
                        principalTable: "Subdistricts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructors_Titles_TitleId",
                        column: x => x.TitleId,
                        principalSchema: "master",
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructorWorkStatuses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstructorId = table.Column<long>(nullable: false),
                    Type = table.Column<string>(maxLength: 2, nullable: true),
                    AdminPosition = table.Column<string>(maxLength: 100, nullable: true),
                    AcademicPosition = table.Column<string>(maxLength: 100, nullable: true),
                    Metier = table.Column<string>(maxLength: 100, nullable: true),
                    Division = table.Column<string>(maxLength: 100, nullable: true),
                    Job = table.Column<string>(maxLength: 100, nullable: true),
                    AcademicLevelId = table.Column<long>(nullable: true),
                    FacultyId = table.Column<long>(nullable: true),
                    DepartmentId = table.Column<long>(nullable: true),
                    OfficeRoom = table.Column<string>(maxLength: 100, nullable: true),
                    TeachingHour = table.Column<decimal>(nullable: false),
                    GraduatedLoad = table.Column<decimal>(nullable: false),
                    UnderGraduateLoad = table.Column<decimal>(nullable: false),
                    Remark = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorWorkStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructorWorkStatuses_AcademicLevels_AcademicLevelId",
                        column: x => x.AcademicLevelId,
                        principalSchema: "master",
                        principalTable: "AcademicLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstructorWorkStatuses_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "master",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstructorWorkStatuses_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "master",
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstructorWorkStatuses_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_CityId",
                table: "Instructors",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_Code",
                table: "Instructors",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_CountryId",
                table: "Instructors",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DistrictId",
                table: "Instructors",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_NationalityId",
                table: "Instructors",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_ProvinceId",
                table: "Instructors",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_RaceId",
                table: "Instructors",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_ReligionId",
                table: "Instructors",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_StateId",
                table: "Instructors",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_SubdistrictId",
                table: "Instructors",
                column: "SubdistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_TitleId",
                table: "Instructors",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWorkStatuses_AcademicLevelId",
                table: "InstructorWorkStatuses",
                column: "AcademicLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWorkStatuses_DepartmentId",
                table: "InstructorWorkStatuses",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWorkStatuses_FacultyId",
                table: "InstructorWorkStatuses",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorWorkStatuses_InstructorId",
                table: "InstructorWorkStatuses",
                column: "InstructorId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstructorWorkStatuses");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
