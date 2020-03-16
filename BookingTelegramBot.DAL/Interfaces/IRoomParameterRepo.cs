using BookingTelegramBot.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.DAL.Interfaces
{
    interface IRoomParameterRepo
    {
        void Insert(RoomParameter roomParameter);
        Task SaveAsync();
    }
}
