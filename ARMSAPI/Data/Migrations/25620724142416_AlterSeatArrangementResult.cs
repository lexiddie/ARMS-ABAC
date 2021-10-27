using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AlterSeatArrangementResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SeatArrangementResult",
                table: "SeatArrangementResult");

            migrationBuilder.RenameTable(
                name: "SeatArrangementResult",
                newName: "SeatArrangementResults");

            migrationBuilder.RenameColumn(
                name: "SeatPosition",
                table: "SeatArrangementResults",
                newName: "SeatNumber");

            migrationBuilder.AddColumn<int>(
                name: "RowNumber",
                table: "SeatArrangementResults",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeatArrangementResults",
                table: "SeatArrangementResults",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SeatArrangementResults",
                table: "SeatArrangementResults");

            migrationBuilder.DropColumn(
                name: "RowNumber",
                table: "SeatArrangementResults");

            migrationBuilder.RenameTable(
                name: "SeatArrangementResults",
                newName: "SeatArrangementResult");

            migrationBuilder.RenameColumn(
                name: "SeatNumber",
                table: "SeatArrangementResult",
                newName: "SeatPosition");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeatArrangementResult",
                table: "SeatArrangementResult",
                column: "Id");
        }
    }
}
