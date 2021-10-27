using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AddAnnouncement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "announcement");

            migrationBuilder.CreateTable(
                name: "Channels",
                schema: "announcement",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameEn = table.Column<string>(maxLength: 200, nullable: false),
                    NameTh = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                schema: "announcement",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 120, nullable: false),
                    Description = table.Column<string>(maxLength: 5000, nullable: true),
                    CoverImageURL = table.Column<string>(maxLength: 2100, nullable: true),
                    Attachments = table.Column<string>(maxLength: 5000, nullable: true),
                    HTMLBody = table.Column<string>(maxLength: 5000, nullable: true),
                    DetailWebUrl = table.Column<string>(maxLength: 2100, nullable: true),
                    IsFlagged = table.Column<bool>(nullable: false),
                    ChannelId = table.Column<long>(nullable: false),
                    StartedAt = table.Column<DateTime>(nullable: false),
                    ExpiredAt = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcements_Channels_ChannelId",
                        column: x => x.ChannelId,
                        principalSchema: "announcement",
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                schema: "announcement",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameEn = table.Column<string>(maxLength: 200, nullable: false),
                    NameTh = table.Column<string>(maxLength: 200, nullable: false),
                    FacultyId = table.Column<long>(nullable: true),
                    DepartmentId = table.Column<long>(nullable: true),
                    ChannelId = table.Column<long>(nullable: false),
                    LogoUrl = table.Column<string>(maxLength: 2100, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_Channels_ChannelId",
                        column: x => x.ChannelId,
                        principalSchema: "announcement",
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Topics_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "master",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Topics_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "master",
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementTopic",
                schema: "announcement",
                columns: table => new
                {
                    AnnouncementId = table.Column<long>(nullable: false),
                    TopicId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementTopic", x => new { x.AnnouncementId, x.TopicId });
                    table.ForeignKey(
                        name: "FK_AnnouncementTopic_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalSchema: "announcement",
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnnouncementTopic_Topics_TopicId",
                        column: x => x.TopicId,
                        principalSchema: "announcement",
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_ChannelId",
                schema: "announcement",
                table: "Announcements",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementTopic_TopicId",
                schema: "announcement",
                table: "AnnouncementTopic",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_ChannelId",
                schema: "announcement",
                table: "Topics",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_DepartmentId",
                schema: "announcement",
                table: "Topics",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_FacultyId",
                schema: "announcement",
                table: "Topics",
                column: "FacultyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnouncementTopic",
                schema: "announcement");

            migrationBuilder.DropTable(
                name: "Announcements",
                schema: "announcement");

            migrationBuilder.DropTable(
                name: "Topics",
                schema: "announcement");

            migrationBuilder.DropTable(
                name: "Channels",
                schema: "announcement");
        }
    }
}
