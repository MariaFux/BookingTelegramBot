using BookingTelegramBot.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTelegramBot.BusinessLogic.Services
{
    interface IRoomService
    {
        IEnumerable<Room> GetAll();
        Room GetRoomByID(int roomID);
        void Inser(Room room);
        void Update(Room room);
        void Delete(int roomID);
        void Save();
    }
}
