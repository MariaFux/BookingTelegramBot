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
    public class RoomUserReservationService : IRoomUserReservationService
    {
        private readonly RoomUserReservationRepo _roomUserReservationRepo;
        private readonly IMapper _mapper;

        public RoomUserReservationService(RoomUserReservationRepo roomUserReservationRepo, IMapper mapper)
        {
            _roomUserReservationRepo = roomUserReservationRepo;
            _mapper = mapper;
        }

        public void Insert(RoomUserReservationDTO roomUserReservationDTO)
        {
            _roomUserReservationRepo.Insert(_mapper.Map<RoomUserReservation>(roomUserReservationDTO));
        }

        public void Delete(RoomUserReservationDTO roomUserReservationDTO)
        {
            _roomUserReservationRepo.Delete(_mapper.Map<RoomUserReservation>(roomUserReservationDTO));
        }

        public async Task SaveAsync()
        {
            await _roomUserReservationRepo.SaveAsync();
        }
    }
}
