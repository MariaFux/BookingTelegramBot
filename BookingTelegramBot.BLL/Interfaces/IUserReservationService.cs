using BookingTelegramBot.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.BLL.Interfaces
{
    interface IUserReservationService
    {
        Task<IEnumerable<UserReservationDTO>> GetAll();
        Task<UserReservationDTO> GetUserReservationById(int userReservationId);
        void Insert(UserReservationDTO userReservation);
        void Update(UserReservationDTO userReservation);
        void Delete(int userReservationId);
        Task Save();
    }
}
