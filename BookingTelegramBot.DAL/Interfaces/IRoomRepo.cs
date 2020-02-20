using BookingTelegramBot.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.DAL.Interfaces
{
    interface IRoomRepo
    {
        Task<IEnumerable<Room>> GetAll();
        Task<Room> GetRoomById(int roomId);
        void Insert(Room room);
        void Update(Room room);
        void Delete(int roomId);
        Task Save();
        Task<IEnumerable<Room>> GetAllWithParameters();
        Task<IEnumerable<Room>> GetAllFree();
    }
}
