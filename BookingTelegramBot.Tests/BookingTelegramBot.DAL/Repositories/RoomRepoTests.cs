using BookingTelegramBot.DAL.EF;
using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookingTelegramBot.Tests.BookingTelegramBot.DAL.Repositories
{
    public class RoomRepoTests
    {
        private BookingRoomDbContext _context;

        public RoomRepoTests(BookingRoomDbContext context)
        {
            _context = context;
        }

        [Fact]
        public async Task GetRoomByIdAsync()
        {
                var repo = new RoomRepo(_context);
                var result = await repo.GetRoomByIdAsync(1);

                var expectedRoom = new Room() { Id = 1, Name = "Room 1", Description = "First", NumberOfPersons = 10 };

                Assert.Equal(expectedRoom.Name, result.Name);
                Assert.Equal(expectedRoom.NumberOfPersons, result.NumberOfPersons);
                Assert.Equal(expectedRoom.RoomParameters.Count, result.RoomParameters.Count); 
        }
    }
}
