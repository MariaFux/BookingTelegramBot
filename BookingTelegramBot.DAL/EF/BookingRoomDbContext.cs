using BookingTelegramBot.DAL.Entities;
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
        }
    }
}
