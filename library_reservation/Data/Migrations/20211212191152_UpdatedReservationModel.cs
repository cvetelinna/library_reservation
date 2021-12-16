using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace library_reservation.Data.Migrations
{
    public partial class UpdatedReservationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Reservations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Reservations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Organizers",
                table: "Reservations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresMultimedia",
                table: "Reservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Reservations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Reservations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Reservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Organizers",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RequiresMultimedia",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reservations");
        }
    }
}
