using Microsoft.EntityFrameworkCore.Migrations;

namespace library_reservation.Data.Migrations
{
    public partial class addsDaysAndMonthsColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReccuringMonths",
                table: "RecurringSettings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecurringDays",
                table: "RecurringSettings",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReccuringMonths",
                table: "RecurringSettings");

            migrationBuilder.DropColumn(
                name: "RecurringDays",
                table: "RecurringSettings");
        }
    }
}
