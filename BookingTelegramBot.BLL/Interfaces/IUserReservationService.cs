using BookingTelegramBot.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.BLL.Interfaces
{
    interface IUserReservationService
    {
        IEnumerable<UserReservation> GetAll();
        UserReservation GetUserReservationById(int userReservationId);
        void Insert(UserReservation userReservation);
        void Update(UserReservation userReservation);
        void Delete(int userReservationId);
        void Save();
    }
}
