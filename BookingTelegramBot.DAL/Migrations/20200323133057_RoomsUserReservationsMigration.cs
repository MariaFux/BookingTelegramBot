using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingTelegramBot.DAL.Migrations
{
    public partial class RoomsUserReservationsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomUserReservation_Rooms_RoomId",
                table: "RoomUserReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomUserReservation_UsersReservations_UserReservationId",
                table: "RoomUserReservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomUserReservation",
                table: "RoomUserReservation");

            migrationBuilder.RenameTable(
                name: "RoomUserReservation",
                newName: "RoomsUserReservations");

            migrationBuilder.RenameIndex(
                name: "IX_RoomUserReservation_UserReservationId",
                table: "RoomsUserReservations",
                newName: "IX_RoomsUserReservations_UserReservationId");

            migrationBuilder.AddColumn<int>(
                name: "TelegramId",
                table: "UsersReservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomsUserReservations",
                table: "RoomsUserReservations",
                columns: new[] { "RoomId", "UserReservationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsUserReservations_Rooms_RoomId",
                table: "RoomsUserReservations",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsUserReservations_UsersReservations_UserReservationId",
                table: "RoomsUserReservations",
                column: "UserReservationId",
                principalTable: "UsersReservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomsUserReservations_Rooms_RoomId",
                table: "RoomsUserReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomsUserReservations_UsersReservations_UserReservationId",
                table: "RoomsUserReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomsUserReservations",
                table: "RoomsUserReservations");

            migrationBuilder.DropColumn(
                name: "TelegramId",
                table: "UsersReservations");

            migrationBuilder.RenameTable(
                name: "RoomsUserReservations",
                newName: "RoomUserReservation");

            migrationBuilder.RenameIndex(
                name: "IX_RoomsUserReservations_UserReservationId",
                table: "RoomUserReservation",
                newName: "IX_RoomUserReservation_UserReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomUserReservation",
                table: "RoomUserReservation",
                columns: new[] { "RoomId", "UserReservationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomUserReservation_Rooms_RoomId",
                table: "RoomUserReservation",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomUserReservation_UsersReservations_UserReservationId",
                table: "RoomUserReservation",
                column: "UserReservationId",
                principalTable: "UsersReservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
