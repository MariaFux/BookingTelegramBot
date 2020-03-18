using BookingTelegramBot.DAL.EF;
using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookingTelegramBot.Tests
{
    public class RoomRepoTests
    {
        [Fact]
        public async Task GetRoomByIdAsync()
        {
            var options = new DbContextOptionsBuilder<BookingRoomDbContext>().UseInMemoryDatabase(databaseName: "BookingRoom").Options;
            using (var context = new BookingRoomDbContext(options))
            {
                context.Rooms.Add(new Room() { Id = 1, Name = "Room 1", Description = "First", NumberOfPersons = 10 });
                context.Rooms.Add(new Room() { Id = 2, Name = "Room 2", Description = "Second", NumberOfPersons = 12 });
                context.Rooms.Add(new Room() { Id = 3, Name = "Room 3", Description = "Third", NumberOfPersons = 15 });
                context.SaveChanges();
            }

            using (var context = new BookingRoomDbContext(options))
            {
                var repo = new RoomRepo(context);
                var result = await repo.GetRoomByIdAsync(1);

                var mockRoom = new Room() { Id = 1, Name = "Room 1", Description = "First", NumberOfPersons = 10 };

                Assert.Equal(mockRoom.Name, result.Name);
                Assert.Equal(mockRoom.NumberOfPersons, result.NumberOfPersons);
                Assert.Equal(mockRoom.RoomParameters.Count, result.RoomParameters.Count);
            }    
        }
    }
}
