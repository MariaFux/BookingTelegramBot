using BookingTelegramBot.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.BLL.Interfaces.v2
{
    interface IRoomService
    {
        Task<IEnumerable<RoomDTO>> GetAllAsync();
        Task<RoomDTO> GetRoomByIdAsync(int roomId);
        void Insert(RoomDTO room);
        void Update(RoomDTO room);
        void Delete(int roomId);
        Task<IEnumerable<RoomDTO>> GetAllWithParametersAsync();
        Task<IEnumerable<RoomDTO>> GetAllFreeAsync();
        int GetRoomIdByName(string roomName);
    }
}
