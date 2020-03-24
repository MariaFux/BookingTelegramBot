using BookingTelegramBot.DAL.EF;
using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.DAL.Repositories
{
    public class RoomUserReservationRepo : IRoomUserReservationRepo
    {
        private readonly BookingRoomDbContext _context;

        public RoomUserReservationRepo(BookingRoomDbContext context)
        {
            _context = context;
        }

        public void Insert(RoomUserReservation roomUserReservation)
        {
            _context.RoomsUserReservations.Add(roomUserReservation);
        }

        public void Delete(RoomUserReservation roomUserReservation)
        {
            _context.RoomsUserReservations.Remove(roomUserReservation);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
