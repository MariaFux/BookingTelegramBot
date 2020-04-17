﻿// <auto-generated />
using System;
using BookingTelegramBot.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookingTelegramBot.DAL.Migrations
{
    [DbContext(typeof(BookingRoomDbContext))]
    [Migration("20200411115215_SeedDataMigration")]
    partial class SeedDataMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookingTelegramBot.DAL.Entities.Parameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameOfParameter")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Parameters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NameOfParameter = "Projector"
                        },
                        new
                        {
                            Id = 2,
                            NameOfParameter = "Display"
                        },
                        new
                        {
                            Id = 3,
                            NameOfParameter = "Computer"
                        },
                        new
                        {
                            Id = 4,
                            NameOfParameter = "Camera"
                        },
                        new
                        {
                            Id = 5,
                            NameOfParameter = "Microphone"
                        },
                        new
                        {
                            Id = 6,
                            NameOfParameter = "Board"
                        },
                        new
                        {
                            Id = 7,
                            NameOfParameter = "Phone"
                        });
                });

            modelBuilder.Entity("BookingTelegramBot.DAL.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserRole = "admin"
                        },
                        new
                        {
                            Id = 2,
                            UserRole = "user"
                        });
                });

            modelBuilder.Entity("BookingTelegramBot.DAL.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPersons")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "First",
                            Name = "Room 1",
                            NumberOfPersons = 10
                        },
                        new
                        {
                            Id = 2,
                            Description = "Second",
                            Name = "Room 2",
                            NumberOfPersons = 15
                        },
                        new
                        {
                            Id = 3,
                            Description = "Third",
                            Name = "Room 3",
                            NumberOfPersons = 7
                        },
                        new
                        {
                            Id = 4,
                            Description = "Fourth",
                            Name = "Room 4",
                            NumberOfPersons = 15
                        },
                        new
                        {
                            Id = 5,
                            Description = "Fifth",
                            Name = "Room 5",
                            NumberOfPersons = 10
                        },
                        new
                        {
                            Id = 6,
                            Description = "Sixth",
                            Name = "Room 6",
                            NumberOfPersons = 15
                        },
                        new
                        {
                            Id = 7,
                            Description = "Seventh",
                            Name = "Room 7",
                            NumberOfPersons = 10
                        },
                        new
                        {
                            Id = 8,
                            Description = "Eighth",
                            Name = "Room 8",
                            NumberOfPersons = 10
                        },
                        new
                        {
                            Id = 9,
                            Description = "Ninth",
                            Name = "Room 9",
                            NumberOfPersons = 7
                        },
                        new
                        {
                            Id = 10,
                            Description = "Tenth",
                            Name = "Room 10",
                            NumberOfPersons = 7
                        });
                });

            modelBuilder.Entity("BookingTelegramBot.DAL.Entities.RoomParameter", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("ParameterId")
                        .HasColumnType("int");

                    b.HasKey("RoomId", "ParameterId");

                    b.HasIndex("ParameterId");

                    b.ToTable("RoomsParameters");

                    b.HasData(
                        new
                        {
                            RoomId = 1,
                            ParameterId = 1
                        },
                        new
                        {
                            RoomId = 1,
                            ParameterId = 2
                        },
                        new
                        {
                            RoomId = 1,
                            ParameterId = 3
                        },
                        new
                        {
                            RoomId = 1,
                            ParameterId = 4
                        },
                        new
                        {
                            RoomId = 1,
                            ParameterId = 5
                        },
                        new
                        {
                            RoomId = 1,
                            ParameterId = 6
                        },
                        new
                        {
                            RoomId = 1,
                            ParameterId = 7
                        },
                        new
                        {
                            RoomId = 2,
                            ParameterId = 1
                        },
                        new
                        {
                            RoomId = 2,
                            ParameterId = 2
                        },
                        new
                        {
                            RoomId = 2,
                            ParameterId = 3
                        },
                        new
                        {
                            RoomId = 2,
                            ParameterId = 4
                        });
                });

            modelBuilder.Entity("BookingTelegramBot.DAL.Entities.RoomUserReservation", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("UserReservationId")
                        .HasColumnType("int");

                    b.HasKey("RoomId", "UserReservationId");

                    b.HasIndex("UserReservationId");

                    b.ToTable("RoomsUserReservations");

                    b.HasData(
                        new
                        {
                            RoomId = 1,
                            UserReservationId = 1
                        },
                        new
                        {
                            RoomId = 2,
                            UserReservationId = 2
                        });
                });

            modelBuilder.Entity("BookingTelegramBot.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("TelegramId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleId = 1,
                            TelegramId = 926681438
                        },
                        new
                        {
                            Id = 2,
                            RoleId = 2,
                            TelegramId = 123123123
                        });
                });

            modelBuilder.Entity("BookingTelegramBot.DAL.Entities.UserReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTimeFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("TelegramId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UsersReservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateTimeFrom = new DateTime(2020, 2, 21, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTimeTo = new DateTime(2020, 2, 21, 15, 30, 0, 0, DateTimeKind.Unspecified),
                            TelegramId = 926681438,
                            UserName = "Maria"
                        },
                        new
                        {
                            Id = 2,
                            DateTimeFrom = new DateTime(2020, 3, 30, 19, 50, 0, 0, DateTimeKind.Unspecified),
                            DateTimeTo = new DateTime(2020, 3, 30, 20, 30, 0, 0, DateTimeKind.Unspecified),
                            TelegramId = 926681438,
                            UserName = "Maria"
                        });
                });

            modelBuilder.Entity("BookingTelegramBot.DAL.Entities.RoomParameter", b =>
                {
                    b.HasOne("BookingTelegramBot.DAL.Entities.Parameter", "Parameter")
                        .WithMany("RoomParameters")
                        .HasForeignKey("ParameterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingTelegramBot.DAL.Entities.Room", "Room")
                        .WithMany("RoomParameters")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingTelegramBot.DAL.Entities.RoomUserReservation", b =>
                {
                    b.HasOne("BookingTelegramBot.DAL.Entities.Room", "Room")
                        .WithMany("RoomUserReservations")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingTelegramBot.DAL.Entities.UserReservation", "UserReservation")
                        .WithMany("RoomUserReservations")
                        .HasForeignKey("UserReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingTelegramBot.DAL.Entities.User", b =>
                {
                    b.HasOne("BookingTelegramBot.DAL.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");
                });
#pragma warning restore 612, 618
        }
    }
}
