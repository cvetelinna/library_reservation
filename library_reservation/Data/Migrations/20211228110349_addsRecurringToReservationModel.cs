using Microsoft.EntityFrameworkCore.Migrations;

namespace library_reservation.Data.Migrations
{
    public partial class addsRecurringToReservationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRecurring",
                table: "Reservations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRecurring",
                table: "Reservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
