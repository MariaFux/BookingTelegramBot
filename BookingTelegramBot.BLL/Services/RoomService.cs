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

        public async Task<IEnumerable<RoomDTO>> GetAll()
        {
            var rooms = await roomRepo.GetAll();
            var roomsDTO = mapper.Map<IEnumerable<RoomDTO>>(rooms);
            return roomsDTO;
        }

        public async Task<RoomDTO> GetRoomById(int roomId)
        {
            var room = await roomRepo.GetRoomById(roomId);
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

        public async Task Save()
        {
            await roomRepo.Save();
        }

        public async Task<IEnumerable<RoomDTO>> GetAllWithParameters()
        {
            var roomParameters = await roomRepo.GetAllWithParameters();
            var roomParametersDTO = mapper.Map<IEnumerable<RoomDTO>>(roomParameters);
            return roomParametersDTO;
        }

        public async Task<IEnumerable<RoomDTO>> GetAllFree()
        {
            var roomFree = await roomRepo.GetAllFree();
            var roomFreeDTO = mapper.Map<IEnumerable<RoomDTO>>(roomFree);
            return roomFreeDTO;
        }
    }
}
