using BookingTelegramBot.DAL.EF;
using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.DAL.Repositories
{
    public class RoomParameterRepo : IRoomParameterRepo
    {
        private readonly BookingRoomDbContext _context;

        public RoomParameterRepo(BookingRoomDbContext context)
        {
            _context = context;
        }

        public void Insert(RoomParameter roomParameter)
        {
            _context.RoomsParameters.Add(roomParameter);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
