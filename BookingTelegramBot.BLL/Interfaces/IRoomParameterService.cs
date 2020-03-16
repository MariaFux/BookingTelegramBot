using BookingTelegramBot.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.BLL.Interfaces
{
    interface IRoomParameterService
    {
        void Insert(RoomParameterDTO roomParameterDTO);
        Task SaveAsync();
    }
}
