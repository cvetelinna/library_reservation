using Microsoft.EntityFrameworkCore.Migrations;

namespace library_reservation.Data.Migrations
{
    public partial class Addstuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_RecurringSettingsId",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "RecurringSettings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RecurringSettingsId",
                table: "Reservations",
                column: "RecurringSettingsId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_RecurringSettingsId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "RecurringSettings");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RecurringSettingsId",
                table: "Reservations",
                column: "RecurringSettingsId");
        }
    }
}
