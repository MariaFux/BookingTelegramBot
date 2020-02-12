using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTelegramBot.Repository.Models
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
    }
}
