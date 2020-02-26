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
        private readonly UserReservationRepo _userReservationRepo;
        private readonly IMapper _mapper;

        public UserReservationService(UserReservationRepo userReservationRepo, IMapper mapper)
        {
            _userReservationRepo = userReservationRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserReservationDTO>> GetAllAsync()
        {
            var reservations = await _userReservationRepo.GetAllAsync();
            var reservationsDTO = _mapper.Map<IEnumerable<UserReservationDTO>>(reservations);
            return reservationsDTO;
        }

        public async Task<UserReservationDTO> GetUserReservationByIdAsync(int userReservationId)
        {
            var reservation = await _userReservationRepo.GetUserReservationByIdAsync(userReservationId);
            var reservationDTO = _mapper.Map<UserReservationDTO>(reservation);
            return reservationDTO;
        }

        public void Insert(UserReservationDTO userReservation)
        {
            _userReservationRepo.Insert(_mapper.Map<UserReservation>(userReservation));
        }

        public void Update(UserReservationDTO userReservation)
        {
            _userReservationRepo.Update(_mapper.Map<UserReservation>(userReservation));
        }

        public void Delete(int userReservationId)
        {
            _userReservationRepo.Delete(userReservationId);
        }

        public async Task SaveAsync()
        {
            await _userReservationRepo.SaveAsync();
        }
    }
}
