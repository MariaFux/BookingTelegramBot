using BookingTelegramBot.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTelegramBot.Repository
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

        public Room GetRoomByID(int roomID)
        {
            return context.Rooms.Find(roomID);
        }

        public void Inser(Room room)
        {
            context.Rooms.Add(room);
        }        

        public void Update(Room room)
        {
            context.Entry(room).State = EntityState.Modified;
        }

        public void Delete(int roomID)
        {
            Room room = context.Rooms.Find(roomID);
            context.Rooms.Remove(room);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
