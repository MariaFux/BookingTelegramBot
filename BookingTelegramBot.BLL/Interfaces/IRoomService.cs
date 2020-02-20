using BookingTelegramBot.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.BLL.Interfaces
{
    interface IRoomService
    {
        Task<IEnumerable<RoomDTO>> GetAll();
        Task<RoomDTO> GetRoomById(int roomId);
        void Insert(RoomDTO room);
        void Update(RoomDTO room);
        void Delete(int roomId);
        Task Save();
        Task<IEnumerable<RoomDTO>> GetAllWithParameters();
        Task<IEnumerable<RoomDTO>> GetAllFree();
    }
}
