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
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

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

            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminName = "Pavel";

            // добавляем роли
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            User adminUser = new User { Id = 1, TelegramName = adminName, RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
        }
    }
}
