using BookingTelegramBot.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.DAL.Interfaces
{
    interface IRoomUserReservationRepo
    {
        void Insert(RoomUserReservation roomUserReservation);
        void Delete(RoomUserReservation roomUserReservation);
        Task SaveAsync();
    }
}
