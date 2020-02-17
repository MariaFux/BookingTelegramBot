using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingTelegramBot.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_Rooms_RoomId",
                table: "Parameters");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersReservations_Rooms_RoomId",
                table: "UsersReservations");

            migrationBuilder.DropIndex(
                name: "IX_UsersReservations_RoomId",
                table: "UsersReservations");

            migrationBuilder.DropIndex(
                name: "IX_Parameters_RoomId",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "UsersReservations");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Parameters");

            migrationBuilder.CreateTable(
                name: "RoomParameter",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false),
                    ParameterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomParameter", x => new { x.RoomId, x.ParameterId });
                    table.ForeignKey(
                        name: "FK_RoomParameter_Parameters_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Parameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomParameter_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomUserReservation",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false),
                    UserReservationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomUserReservation", x => new { x.RoomId, x.UserReservationId });
                    table.ForeignKey(
                        name: "FK_RoomUserReservation_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomUserReservation_UsersReservations_UserReservationId",
                        column: x => x.UserReservationId,
                        principalTable: "UsersReservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomParameter_ParameterId",
                table: "RoomParameter",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomUserReservation_UserReservationId",
                table: "RoomUserReservation",
                column: "UserReservationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomParameter");

            migrationBuilder.DropTable(
                name: "RoomUserReservation");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "UsersReservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Parameters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersReservations_RoomId",
                table: "UsersReservations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_RoomId",
                table: "Parameters",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_Rooms_RoomId",
                table: "Parameters",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersReservations_Rooms_RoomId",
                table: "UsersReservations",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
