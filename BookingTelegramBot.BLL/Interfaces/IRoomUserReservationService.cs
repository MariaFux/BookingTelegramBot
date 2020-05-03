using BookingTelegramBot.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.BLL.Interfaces
{
    interface IRoomUserReservationService
    {
        void Insert(RoomUserReservationDTO roomUserReservationDTO);
        void Delete(RoomUserReservationDTO roomUserReservationDTO);
        Task SaveAsync();
    }
}
