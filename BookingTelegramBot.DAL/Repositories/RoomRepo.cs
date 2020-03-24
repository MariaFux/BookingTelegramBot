using BookingTelegramBot.DAL.EF;
using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.DAL.Repositories
{
    public class RoomRepo : IRoomRepo
    {
        private readonly BookingRoomDbContext _context;

        public RoomRepo(BookingRoomDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room> GetRoomByIdAsync(int roomId)
        {
            return await _context.Rooms.FindAsync(roomId);
        }

        public void Insert(Room room)
        {
            _context.Rooms.Add(room);
        }

        public void Update(Room room)
        {
            var attached = _context.Rooms.Local.FirstOrDefault(x => x.Id == room.Id);

            if (attached != null)
            {
                _context.Entry(attached).CurrentValues.SetValues(room);
            }
            else
            {
                _context.Entry(room).State = EntityState.Modified;
            }
        }        

        public void Delete(int roomId)
        {
            Room room = _context.Rooms.Find(roomId);
            _context.Rooms.Remove(room);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Room>> GetAllWithParametersAsync()
        {
            return await _context.Rooms.Include(p => p.RoomParameters).ThenInclude(p => p.Parameter).ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetAllFreeAsync()
        {
            return await _context.Rooms.Include(p => p.RoomUserReservations).ThenInclude(p => p.UserReservation).ToListAsync();
        }

        public int GetRoomIdByName(string roomName)
        {
            Room room = _context.Rooms.FirstOrDefault(x => x.Name == roomName);
            return room.Id;
        }
    }
}
