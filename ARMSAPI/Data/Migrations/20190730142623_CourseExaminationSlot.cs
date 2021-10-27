using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class CourseExaminationSlot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectionExaminationSlot",
                schema: "master");

            migrationBuilder.AddColumn<long>(
                name: "ExaminationTypeId",
                schema: "master",
                table: "ExaminationSlot",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "CourseExaminationSlot",
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
                    CourseId = table.Column<long>(nullable: false),
                    ExaminationSlotId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseExaminationSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseExaminationSlot_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseExaminationSlot_ExaminationSlot_ExaminationSlotId",
                        column: x => x.ExaminationSlotId,
                        principalSchema: "master",
                        principalTable: "ExaminationSlot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationSlot_ExaminationTypeId",
                schema: "master",
                table: "ExaminationSlot",
                column: "ExaminationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseExaminationSlot_CourseId",
                schema: "master",
                table: "CourseExaminationSlot",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseExaminationSlot_ExaminationSlotId",
                schema: "master",
                table: "CourseExaminationSlot",
                column: "ExaminationSlotId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExaminationSlot_ExaminationTypes_ExaminationTypeId",
                schema: "master",
                table: "ExaminationSlot");

            migrationBuilder.DropTable(
                name: "CourseExaminationSlot",
                schema: "master");

            migrationBuilder.DropIndex(
                name: "IX_ExaminationSlot_ExaminationTypeId",
                schema: "master",
                table: "ExaminationSlot");

            migrationBuilder.DropColumn(
                name: "ExaminationTypeId",
                schema: "master",
                table: "ExaminationSlot");

            migrationBuilder.CreateTable(
                name: "SectionExaminationSlot",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    ExaminationSlotId = table.Column<long>(nullable: false),
                    ExaminationTypeId = table.Column<long>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    SectionId = table.Column<long>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionExaminationSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionExaminationSlot_ExaminationSlot_ExaminationSlotId",
                        column: x => x.ExaminationSlotId,
                        principalSchema: "master",
                        principalTable: "ExaminationSlot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionExaminationSlot_ExaminationTypes_ExaminationTypeId",
                        column: x => x.ExaminationTypeId,
                        principalSchema: "master",
                        principalTable: "ExaminationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionExaminationSlot_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SectionExaminationSlot_ExaminationSlotId",
                schema: "master",
                table: "SectionExaminationSlot",
                column: "ExaminationSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionExaminationSlot_ExaminationTypeId",
                schema: "master",
                table: "SectionExaminationSlot",
                column: "ExaminationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionExaminationSlot_SectionId",
                schema: "master",
                table: "SectionExaminationSlot",
                column: "SectionId");
        }
    }
}
