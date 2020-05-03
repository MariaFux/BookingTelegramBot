using BookingTelegramBot.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.DAL.Interfaces
{
    interface IUserReservationRepo
    {
        Task<IEnumerable<UserReservation>> GetAllAsync();
        Task<UserReservation> GetUserReservationByIdAsync(int userReservationId);
        void Insert(UserReservation userReservation);
        void Update(UserReservation userReservation);
        void Delete(int userReservationId);
        Task SaveAsync();
        Task<IEnumerable<UserReservation>> GetReservationByTelegramIdAsync(int telegramId);
    }
}
