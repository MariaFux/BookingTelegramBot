using BookingTelegramBot.DAL.EF;
using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingTelegramBot.DAL.Repositories
{
    public class RoomRepo : IRoomRepo
    {
        public BookingRoomDbContext context;

        public RoomRepo(BookingRoomDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Room> GetAll()
        {
            return context.Rooms.ToList();
        }

        public Room GetRoomById(int roomId)
        {
            return context.Rooms.Find(roomId);
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

        public void Save()
        {
            context.SaveChanges();
        }

        public IEnumerable<Room> GetAllWithParameters()
        {
            return context.Rooms.Include(p => p.RoomParameters).ThenInclude(p => p.Parameter);
        }
    }
}
