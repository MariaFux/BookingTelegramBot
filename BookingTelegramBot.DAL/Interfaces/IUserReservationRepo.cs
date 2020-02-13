using BookingTelegramBot.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.DAL.Interfaces
{
    interface IUserReservationRepo
    {
        IEnumerable<UserReservation> GetAll();
        UserReservation GetUserReservationById(int userReservationId);
        void Insert(UserReservation userReservation);
        void Update(UserReservation userReservation);
        void Delete(int userReservationId);
        void Save();
    }
}
