using BookingTelegramBot.DAL.EF;
using BookingTelegramBot.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingTelegramBot.Tests
{
    public class BookingRoomDbContextInitialize
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookingRoomDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookingRoomDbContext>>()))
            {
                if (context.Rooms.Any())
                {
                    return;
                }

                context.Rooms.AddRange(
                    new Room { Id = 1, Name = "Room 1", Description = "First", NumberOfPersons = 10 },
                    new Room { Id = 2, Name = "Room 2", Description = "Second", NumberOfPersons = 12 },
                    new Room { Id = 3, Name = "Room 3", Description = "Third", NumberOfPersons = 15 }
                    );

                context.SaveChanges();
            }
        }
    }
}
