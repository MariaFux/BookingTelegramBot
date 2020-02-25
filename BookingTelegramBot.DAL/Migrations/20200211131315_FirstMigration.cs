using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingTelegramBot.DAL.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfPersons = table.Column<int>(nullable: false),
                    Projector = table.Column<bool>(nullable: false),
                    ProjectorControlPanel = table.Column<bool>(nullable: false),
                    Display = table.Column<bool>(nullable: false),
                    Computer = table.Column<bool>(nullable: false),
                    Microphone = table.Column<bool>(nullable: false),
                    Camera = table.Column<bool>(nullable: false),
                    Board = table.Column<bool>(nullable: false),
                    CountOfTable = table.Column<int>(nullable: false),
                    CountOfChairs = table.Column<int>(nullable: false),
                    Phone = table.Column<bool>(nullable: false),
                    RoomId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Parameters_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersReservations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    TimeFrom = table.Column<DateTime>(nullable: false),
                    TimeTo = table.Column<DateTime>(nullable: false),
                    RoomId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersReservations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsersReservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_RoomId",
                table: "Parameters",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersReservations_RoomId",
                table: "UsersReservations",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parameters");

            migrationBuilder.DropTable(
                name: "UsersReservations");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
