using Microsoft.EntityFrameworkCore.Migrations;

namespace library_reservation.Data.Migrations
{
    public partial class updateUserIdcolumnreservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Halls_HallId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_RecurringSettings_RecurringSettingsId",
                table: "Reservations");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reservations",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "Reservations",
                type: "TEXT",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Organizers",
                table: "Reservations",
                type: "TEXT",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Halls_HallId",
                table: "Reservations",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id");

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
                name: "FK_Reservations_Halls_HallId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_RecurringSettings_RecurringSettingsId",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Reservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "Reservations",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Organizers",
                table: "Reservations",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 30);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Halls_HallId",
                table: "Reservations",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_RecurringSettings_RecurringSettingsId",
                table: "Reservations",
                column: "RecurringSettingsId",
                principalTable: "RecurringSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
