using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingTelegramBot.DAL.Migrations
{
    public partial class SeedDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "NameOfParameter" },
                values: new object[,]
                {
                    { 1, "Projector" },
                    { 2, "Display" },
                    { 3, "Computer" },
                    { 4, "Camera" },
                    { 5, "Microphone" },
                    { 6, "Board" },
                    { 7, "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Description", "Name", "NumberOfPersons" },
                values: new object[,]
                {
                    { 10, "Tenth", "Room 10", 7 },
                    { 9, "Ninth", "Room 9", 7 },
                    { 8, "Eighth", "Room 8", 10 },
                    { 7, "Seventh", "Room 7", 10 },
                    { 6, "Sixth", "Room 6", 15 },
                    { 4, "Fourth", "Room 4", 15 },
                    { 3, "Third", "Room 3", 7 },
                    { 2, "Second", "Room 2", 15 },
                    { 1, "First", "Room 1", 10 },
                    { 5, "Fifth", "Room 5", 10 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "RoleId", "TelegramId" },
                values: new object[,]
                {
                    { 1, 1, 926681438 },
                    { 2, 2, 123123123 }
                });

            migrationBuilder.InsertData(
                table: "UsersReservations",
                columns: new[] { "Id", "DateTimeFrom", "DateTimeTo", "TelegramId", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 2, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 21, 15, 30, 0, 0, DateTimeKind.Unspecified), 926681438, "Maria" },
                    { 2, new DateTime(2020, 3, 30, 19, 50, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 30, 20, 30, 0, 0, DateTimeKind.Unspecified), 926681438, "Maria" }
                });

            migrationBuilder.InsertData(
                table: "RoomsParameters",
                columns: new[] { "RoomId", "ParameterId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "RoomsUserReservations",
                columns: new[] { "RoomId", "UserReservationId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RoomsParameters",
                keyColumns: new[] { "RoomId", "ParameterId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RoomsParameters",
                keyColumns: new[] { "RoomId", "ParameterId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "RoomsParameters",
                keyColumns: new[] { "RoomId", "ParameterId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "RoomsParameters",
                keyColumns: new[] { "RoomId", "ParameterId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "RoomsParameters",
                keyColumns: new[] { "RoomId", "ParameterId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "RoomsParameters",
                keyColumns: new[] { "RoomId", "ParameterId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "RoomsParameters",
                keyColumns: new[] { "RoomId", "ParameterId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "RoomsParameters",
                keyColumns: new[] { "RoomId", "ParameterId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "RoomsParameters",
                keyColumns: new[] { "RoomId", "ParameterId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "RoomsParameters",
                keyColumns: new[] { "RoomId", "ParameterId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "RoomsParameters",
                keyColumns: new[] { "RoomId", "ParameterId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "RoomsUserReservations",
                keyColumns: new[] { "RoomId", "UserReservationId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RoomsUserReservations",
                keyColumns: new[] { "RoomId", "UserReservationId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Parameters",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UsersReservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UsersReservations",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
