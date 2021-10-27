using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AddIsAllowAutoAssign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAllowAutoAssign",
                schema: "master",
                table: "Rooms",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAllowAutoAssign",
                schema: "master",
                table: "Rooms");
        }
    }
}
