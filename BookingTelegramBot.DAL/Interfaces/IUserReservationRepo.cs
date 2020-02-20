using BookingTelegramBot.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.DAL.Interfaces
{
    interface IUserReservationRepo
    {
        Task<IEnumerable<UserReservation>> GetAll();
        Task<UserReservation> GetUserReservationById(int userReservationId);
        void Insert(UserReservation userReservation);
        void Update(UserReservation userReservation);
        void Delete(int userReservationId);
        Task Save();
    }
}
