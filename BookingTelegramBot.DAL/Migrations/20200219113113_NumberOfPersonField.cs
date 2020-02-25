using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingTelegramBot.DAL.Migrations
{
    public partial class NumberOfPersonField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnotherDescription",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPersons",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfPersons",
                table: "Rooms");

            migrationBuilder.AddColumn<string>(
                name: "AnotherDescription",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
