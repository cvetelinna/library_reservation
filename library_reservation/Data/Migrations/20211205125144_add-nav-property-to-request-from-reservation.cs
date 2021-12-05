using Microsoft.EntityFrameworkCore.Migrations;

namespace library_reservation.Data.Migrations
{
    public partial class addnavpropertytorequestfromreservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ReservationRequests_ReservationId",
                table: "ReservationRequests");

            migrationBuilder.AddColumn<int>(
                name: "ReservationRequestId",
                table: "Reservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRequests_ReservationId",
                table: "ReservationRequests",
                column: "ReservationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ReservationRequests_ReservationId",
                table: "ReservationRequests");

            migrationBuilder.DropColumn(
                name: "ReservationRequestId",
                table: "Reservations");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRequests_ReservationId",
                table: "ReservationRequests",
                column: "ReservationId");
        }
    }
}
