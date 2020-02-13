using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingTelegramBot.Migrations
{
    public partial class ParameterMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Board",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "Camera",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "Computer",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "CountOfChairs",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "CountOfTable",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "Display",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "Microphone",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "NumberOfPersons",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "Projector",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "ProjectorControlPanel",
                table: "Parameters");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "UsersReservations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Rooms",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Parameters",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "NameOfParameter",
                table: "Parameters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameOfParameter",
                table: "Parameters");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UsersReservations",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rooms",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Parameters",
                newName: "ID");

            migrationBuilder.AddColumn<bool>(
                name: "Board",
                table: "Parameters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Camera",
                table: "Parameters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Computer",
                table: "Parameters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CountOfChairs",
                table: "Parameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountOfTable",
                table: "Parameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Display",
                table: "Parameters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Microphone",
                table: "Parameters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPersons",
                table: "Parameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Phone",
                table: "Parameters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Projector",
                table: "Parameters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ProjectorControlPanel",
                table: "Parameters",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
