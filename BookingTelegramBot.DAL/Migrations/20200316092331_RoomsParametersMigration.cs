using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingTelegramBot.DAL.Migrations
{
    public partial class RoomsParametersMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomParameter_Parameters_ParameterId",
                table: "RoomParameter");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomParameter_Rooms_RoomId",
                table: "RoomParameter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomParameter",
                table: "RoomParameter");

            migrationBuilder.RenameTable(
                name: "RoomParameter",
                newName: "RoomsParameters");

            migrationBuilder.RenameIndex(
                name: "IX_RoomParameter_ParameterId",
                table: "RoomsParameters",
                newName: "IX_RoomsParameters_ParameterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomsParameters",
                table: "RoomsParameters",
                columns: new[] { "RoomId", "ParameterId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsParameters_Parameters_ParameterId",
                table: "RoomsParameters",
                column: "ParameterId",
                principalTable: "Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsParameters_Rooms_RoomId",
                table: "RoomsParameters",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomsParameters_Parameters_ParameterId",
                table: "RoomsParameters");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomsParameters_Rooms_RoomId",
                table: "RoomsParameters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomsParameters",
                table: "RoomsParameters");

            migrationBuilder.RenameTable(
                name: "RoomsParameters",
                newName: "RoomParameter");

            migrationBuilder.RenameIndex(
                name: "IX_RoomsParameters_ParameterId",
                table: "RoomParameter",
                newName: "IX_RoomParameter_ParameterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomParameter",
                table: "RoomParameter",
                columns: new[] { "RoomId", "ParameterId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomParameter_Parameters_ParameterId",
                table: "RoomParameter",
                column: "ParameterId",
                principalTable: "Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomParameter_Rooms_RoomId",
                table: "RoomParameter",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
