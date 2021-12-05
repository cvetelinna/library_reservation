using Microsoft.EntityFrameworkCore.Migrations;

namespace library_reservation.Data.Migrations
{
    public partial class addnavpropertytoreservationrequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ReservationRequests_ReservationId",
                table: "ReservationRequests",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationRequests_Reservations_ReservationId",
                table: "ReservationRequests",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationRequests_Reservations_ReservationId",
                table: "ReservationRequests");

            migrationBuilder.DropIndex(
                name: "IX_ReservationRequests_ReservationId",
                table: "ReservationRequests");
        }
    }
}
