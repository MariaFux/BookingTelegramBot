using AutoMapper;
using BookingTelegramBot.BLL.DTO;
using BookingTelegramBot.BLL.Interfaces;
using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.BLL.Services
{
    public class UserReservationService : IUserReservationService
    {
        public UserReservationRepo userReservationRepo;
        private readonly IMapper mapper;

        public UserReservationService(UserReservationRepo userReservationRepo, IMapper mapper)
        {
            this.userReservationRepo = userReservationRepo;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<UserReservationDTO>> GetAll()
        {
            var reservations = await userReservationRepo.GetAll();
            var reservationsDTO = mapper.Map<IEnumerable<UserReservationDTO>>(reservations);
            return reservationsDTO;
        }

        public async Task<UserReservationDTO> GetUserReservationById(int userReservationId)
        {
            var reservation = await userReservationRepo.GetUserReservationById(userReservationId);
            var reservationDTO = mapper.Map<UserReservationDTO>(reservation);
            return reservationDTO;
        }

        public void Insert(UserReservationDTO userReservation)
        {
            userReservationRepo.Insert(mapper.Map<UserReservation>(userReservation));
        }

        public void Update(UserReservationDTO userReservation)
        {
            userReservationRepo.Update(mapper.Map<UserReservation>(userReservation));
        }

        public void Delete(int userReservationId)
        {
            userReservationRepo.Delete(userReservationId);
        }

        public async Task Save()
        {
            await userReservationRepo.Save();
        }
    }
}
