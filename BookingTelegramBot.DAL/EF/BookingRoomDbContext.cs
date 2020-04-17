using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.DAL.EF
{
    public class BookingRoomDbContext : DbContext
    {
        public BookingRoomDbContext(DbContextOptions<BookingRoomDbContext> options) : base(options)
        {
        }

        public BookingRoomDbContext()
        {
        }

        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<UserReservation> UsersReservations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RoomParameter> RoomsParameters { get; set; }
        public DbSet<RoomUserReservation> RoomsUserReservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomParameter>()
                .HasKey(t => new { t.RoomId, t.ParameterId });

            modelBuilder.Entity<RoomParameter>()
                .HasOne(rp => rp.Room)
                .WithMany(r => r.RoomParameters)
                .HasForeignKey(rp => rp.RoomId);

            modelBuilder.Entity<RoomParameter>()
                .HasOne(rp => rp.Parameter)
                .WithMany(p => p.RoomParameters)
                .HasForeignKey(rp => rp.ParameterId);

            modelBuilder.Entity<RoomUserReservation>()
                .HasKey(t => new { t.RoomId, t.UserReservationId });

            modelBuilder.Entity<RoomUserReservation>()
                .HasOne(rp => rp.Room)
                .WithMany(r => r.RoomUserReservations)
                .HasForeignKey(rp => rp.RoomId);

            modelBuilder.Entity<RoomUserReservation>()
                .HasOne(rp => rp.UserReservation)
                .WithMany(p => p.RoomUserReservations)
                .HasForeignKey(rp => rp.UserReservationId);

            modelBuilder.Entity<Role>()
                .Property(e => e.UserRole)
                .HasConversion(v => v.ToString(),
                v => (Roles)Enum.Parse(typeof(Roles), v));

            modelBuilder.Entity<Role>().HasData(new Role[] { 
                new Role { Id = 1, UserRole = Roles.admin }, 
                new Role { Id = 2, UserRole = Roles.user } 
            });

            modelBuilder.Entity<Room>().HasData(new Room[] {
                new Room() { Id = 1, Name = "Room 1", Description = "First", NumberOfPersons = 10 },
                new Room() { Id = 2, Name = "Room 2", Description = "Second", NumberOfPersons = 15 },
                new Room() { Id = 3, Name = "Room 3", Description = "Third", NumberOfPersons = 7 },
                new Room() { Id = 4, Name = "Room 4", Description = "Fourth", NumberOfPersons = 15 },
                new Room() { Id = 5, Name = "Room 5", Description = "Fifth", NumberOfPersons = 10 },
                new Room() { Id = 6, Name = "Room 6", Description = "Sixth", NumberOfPersons = 15 },
                new Room() { Id = 7, Name = "Room 7", Description = "Seventh", NumberOfPersons = 10 },
                new Room() { Id = 8, Name = "Room 8", Description = "Eighth", NumberOfPersons = 10 },
                new Room() { Id = 9, Name = "Room 9", Description = "Ninth", NumberOfPersons = 7 },
                new Room() { Id = 10, Name = "Room 10", Description = "Tenth", NumberOfPersons = 7 }
            });

            modelBuilder.Entity<Parameter>().HasData(new Parameter[] {
                new Parameter() { Id = 1, NameOfParameter = "Projector" },
                new Parameter() { Id = 2, NameOfParameter = "Display" },
                new Parameter() { Id = 3, NameOfParameter = "Computer" },
                new Parameter() { Id = 4, NameOfParameter = "Camera" },
                new Parameter() { Id = 5, NameOfParameter = "Microphone" },
                new Parameter() { Id = 6, NameOfParameter = "Board" },
                new Parameter() { Id = 7, NameOfParameter = "Phone" }
            });

            modelBuilder.Entity<User>().HasData(new User[] {
                new User() { Id = 1, TelegramId = 926681438, RoleId = 1 },
                new User() { Id = 2, TelegramId = 123123123, RoleId = 2 }
            });

            modelBuilder.Entity<RoomParameter>().HasData(new RoomParameter[] {
                new RoomParameter() { RoomId = 1, ParameterId = 1 },
                new RoomParameter() { RoomId = 1, ParameterId = 2 },
                new RoomParameter() { RoomId = 1, ParameterId = 3 },
                new RoomParameter() { RoomId = 1, ParameterId = 4 },
                new RoomParameter() { RoomId = 1, ParameterId = 5 },
                new RoomParameter() { RoomId = 1, ParameterId = 6 },
                new RoomParameter() { RoomId = 1, ParameterId = 7 },
                new RoomParameter() { RoomId = 2, ParameterId = 1 },
                new RoomParameter() { RoomId = 2, ParameterId = 2 },
                new RoomParameter() { RoomId = 2, ParameterId = 3 },
                new RoomParameter() { RoomId = 2, ParameterId = 4 }
            });

            modelBuilder.Entity<UserReservation>().HasData(new UserReservation[] {
                new UserReservation() { Id = 1, DateTimeFrom = Convert.ToDateTime("2020-02-21 15:00"), DateTimeTo = Convert.ToDateTime("2020-02-21 15:30"), TelegramId = 926681438, UserName = "Maria" },
                new UserReservation() { Id = 2, DateTimeFrom = Convert.ToDateTime("2020-03-30 19:50"), DateTimeTo = Convert.ToDateTime("2020-03-30 20:30"), TelegramId = 926681438, UserName = "Maria" }
            });

            modelBuilder.Entity<RoomUserReservation>().HasData(new RoomUserReservation[] {
                new RoomUserReservation() { RoomId = 1, UserReservationId = 1 },
                new RoomUserReservation() { RoomId = 2, UserReservationId = 2 }
            });
        }
    }
}
