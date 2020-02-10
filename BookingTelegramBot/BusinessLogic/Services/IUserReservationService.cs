using BookingTelegramBot.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTelegramBot.BusinessLogic.Services
{
    interface IUserReservationService
    {
        IEnumerable<UserReservation> GetAll();
        UserReservation GetUserReservationByID(int userReservationID);
        void Insert(UserReservation userReservation);
        void Update(UserReservation userReservation);
        void Delete(int userReservationID);
        void Save();
    }
}
