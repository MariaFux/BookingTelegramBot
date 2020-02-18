using BookingTelegramBot.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.BLL.Interfaces
{
    interface IRoomService
    {
        IEnumerable<Room> GetAll();
        Room GetRoomById(int roomId);
        void Insert(Room room);
        void Update(Room room);
        void Delete(int roomId);
        void Save();
        IEnumerable<Room> GetAllWithParameters();
    }
}
