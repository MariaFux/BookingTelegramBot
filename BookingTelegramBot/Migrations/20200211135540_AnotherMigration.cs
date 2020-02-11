using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingTelegramBot.Migrations
{
    public partial class AnotherMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnotherDescription",
                table: "Rooms",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnotherDescription",
                table: "Rooms");
        }
    }
}
