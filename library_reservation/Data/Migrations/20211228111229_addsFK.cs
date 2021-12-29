using Microsoft.EntityFrameworkCore.Migrations;

namespace library_reservation.Data.Migrations
{
    public partial class addsFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RecurringSettingsId",
                table: "Reservations",
                column: "RecurringSettingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_RecurringSettings_RecurringSettingsId",
                table: "Reservations",
                column: "RecurringSettingsId",
                principalTable: "RecurringSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_RecurringSettings_RecurringSettingsId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RecurringSettingsId",
                table: "Reservations");
        }
    }
}
