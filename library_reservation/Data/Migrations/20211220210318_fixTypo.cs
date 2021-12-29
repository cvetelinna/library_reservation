using Microsoft.EntityFrameworkCore.Migrations;

namespace library_reservation.Data.Migrations
{
    public partial class fixTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReccuringSettingsId",
                table: "Reservations",
                newName: "RecurringSettingsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecurringSettingsId",
                table: "Reservations",
                newName: "ReccuringSettingsId");
        }
    }
}
