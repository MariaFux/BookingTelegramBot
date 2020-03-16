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
    public class RoomParameterService : IRoomParameterService
    {
        private readonly RoomParameterRepo _roomParameterRepo;
        private readonly IMapper _mapper;

        public RoomParameterService(RoomParameterRepo roomParameterRepo, IMapper mapper)
        {
            _roomParameterRepo = roomParameterRepo;
            _mapper = mapper;
        }

        public void Insert(RoomParameterDTO roomParameterDTO)
        {
            _roomParameterRepo.Insert(_mapper.Map<RoomParameter>(roomParameterDTO));
        }

        public async Task SaveAsync()
        {
            await _roomParameterRepo.SaveAsync();
        }
    }
}
