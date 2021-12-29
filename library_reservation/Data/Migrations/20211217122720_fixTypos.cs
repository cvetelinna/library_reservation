using Microsoft.EntityFrameworkCore.Migrations;

namespace library_reservation.Data.Migrations
{
    public partial class fixTypos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReccuringMonths",
                table: "RecurringSettings",
                newName: "RecurrinMonths");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecurrinMonths",
                table: "RecurringSettings",
                newName: "ReccuringMonths");
        }
    }
}
