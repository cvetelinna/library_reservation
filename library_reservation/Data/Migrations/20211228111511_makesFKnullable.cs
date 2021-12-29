using Microsoft.EntityFrameworkCore.Migrations;

namespace library_reservation.Data.Migrations
{
    public partial class makesFKnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_RecurringSettings_RecurringSettingsId",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "RecurringSettingsId",
                table: "Reservations",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_RecurringSettings_RecurringSettingsId",
                table: "Reservations",
                column: "RecurringSettingsId",
                principalTable: "RecurringSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_RecurringSettings_RecurringSettingsId",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "RecurringSettingsId",
                table: "Reservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_RecurringSettings_RecurringSettingsId",
                table: "Reservations",
                column: "RecurringSettingsId",
                principalTable: "RecurringSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
