using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AlterRegistrationSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "registration");

            migrationBuilder.RenameTable(
                name: "Slots",
                newName: "Slots",
                newSchema: "registration");

            migrationBuilder.RenameTable(
                name: "RegistrationSlots",
                newName: "RegistrationSlots",
                newSchema: "registration");

            migrationBuilder.RenameTable(
                name: "RegistrationResults",
                newName: "RegistrationResults",
                newSchema: "registration");

            migrationBuilder.RenameTable(
                name: "CreditLoads",
                newName: "CreditLoads",
                newSchema: "registration");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Slots",
                schema: "registration",
                newName: "Slots");

            migrationBuilder.RenameTable(
                name: "RegistrationSlots",
                schema: "registration",
                newName: "RegistrationSlots");

            migrationBuilder.RenameTable(
                name: "RegistrationResults",
                schema: "registration",
                newName: "RegistrationResults");

            migrationBuilder.RenameTable(
                name: "CreditLoads",
                schema: "registration",
                newName: "CreditLoads");
        }
    }
}
