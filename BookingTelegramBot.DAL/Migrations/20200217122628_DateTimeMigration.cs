using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingTelegramBot.DAL.Migrations
{
    public partial class DateTimeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "UsersReservations");

            migrationBuilder.DropColumn(
                name: "TimeFrom",
                table: "UsersReservations");

            migrationBuilder.DropColumn(
                name: "TimeTo",
                table: "UsersReservations");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeFrom",
                table: "UsersReservations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeTo",
                table: "UsersReservations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeFrom",
                table: "UsersReservations");

            migrationBuilder.DropColumn(
                name: "DateTimeTo",
                table: "UsersReservations");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "UsersReservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeFrom",
                table: "UsersReservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeTo",
                table: "UsersReservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
