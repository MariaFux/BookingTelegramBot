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
        public BookingRoomDbContext context;

        public RoomRepo(BookingRoomDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await context.Rooms.ToListAsync();
        }

        public async Task<Room> GetRoomByIdAsync(int roomId)
        {
            return await context.Rooms.FindAsync(roomId);
        }

        public void Insert(Room room)
        {
            context.Rooms.Add(room);
        }

        public void Update(Room room)
        {
            context.Entry(room).State = EntityState.Modified;
        }

        public void Delete(int roomId)
        {
            Room room = context.Rooms.Find(roomId);
            context.Rooms.Remove(room);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Room>> GetAllWithParametersAsync()
        {
            return await context.Rooms.Include(p => p.RoomParameters).ThenInclude(p => p.Parameter).ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetAllFreeAsync()
        {
            return await context.Rooms.Include(p => p.RoomUserReservations).ThenInclude(p => p.UserReservation).ToListAsync();
        }
    }
}
