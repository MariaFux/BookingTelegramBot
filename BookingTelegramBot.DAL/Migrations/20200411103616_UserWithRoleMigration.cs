using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingTelegramBot.DAL.Migrations
{
    public partial class UserWithRoleMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "RoleId", "TelegramId" },
                values: new object[] { 1, 1, 0 });
        }
    }
}
