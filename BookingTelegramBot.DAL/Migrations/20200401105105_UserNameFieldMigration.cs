using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingTelegramBot.DAL.Migrations
{
    public partial class UserNameFieldMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "UsersReservations");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "UsersReservations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "UsersReservations");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UsersReservations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
