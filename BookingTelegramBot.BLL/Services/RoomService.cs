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
    public class RoomService : IRoomService
    {
        public RoomRepo roomRepo;
        private readonly IMapper mapper;

        public RoomService(RoomRepo roomRepo, IMapper mapper)
        {
            this.roomRepo = roomRepo;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<RoomDTO>> GetAllAsync()
        {
            var rooms = await roomRepo.GetAllAsync();
            var roomsDTO = mapper.Map<IEnumerable<RoomDTO>>(rooms);
            return roomsDTO;
        }

        public async Task<RoomDTO> GetRoomByIdAsync(int roomId)
        {
            var room = await roomRepo.GetRoomByIdAsync(roomId);
            var roomDTO = mapper.Map<RoomDTO>(room);
            return roomDTO;
        }

        public void Insert(RoomDTO room)
        {
            roomRepo.Insert(mapper.Map<Room>(room));
        }

        public void Update(RoomDTO room)
        {
            roomRepo.Update(mapper.Map<Room>(room));
        }

        public void Delete(int roomId)
        {
            roomRepo.Delete(roomId);
        }

        public async Task SaveAsync()
        {
            await roomRepo.SaveAsync();
        }

        public async Task<IEnumerable<RoomDTO>> GetAllWithParametersAsync()
        {
            var roomParameters = await roomRepo.GetAllWithParametersAsync();
            var roomParametersDTO = mapper.Map<IEnumerable<RoomDTO>>(roomParameters);
            return roomParametersDTO;
        }

        public async Task<IEnumerable<RoomDTO>> GetAllFreeAsync()
        {
            var roomFree = await roomRepo.GetAllFreeAsync();
            var roomFreeDTO = mapper.Map<IEnumerable<RoomDTO>>(roomFree);
            return roomFreeDTO;
        }
    }
}
