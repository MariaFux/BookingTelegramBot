using AutoMapper;
using BookingTelegramBot.BLL.DTO;
using BookingTelegramBot.BLL.Interfaces.v2;
using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Repositories.v2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.BLL.Services.v2
{
    public class RoomServiceV2 : IRoomService
    {
        private readonly RoomRepoV2 _roomRepo;
        private readonly IMapper _mapper;

        public RoomServiceV2(RoomRepoV2 roomRepo, IMapper mapper)
        {
            _roomRepo = roomRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomDTO>> GetAllAsync()
        {
            var rooms = await _roomRepo.GetAllAsync();
            var roomsDTO = _mapper.Map<IEnumerable<RoomDTO>>(rooms);
            return roomsDTO;
        }

        public async Task<RoomDTO> GetRoomByIdAsync(int roomId)
        {
            var room = await _roomRepo.GetRoomByIdAsync(roomId);
            var roomDTO = _mapper.Map<RoomDTO>(room);
            return roomDTO;
        }

        public void Insert(RoomDTO room)
        {
            _roomRepo.Insert(_mapper.Map<Room>(room));
        }

        public void Update(RoomDTO room)
        {
            _roomRepo.Update(_mapper.Map<Room>(room));
        }

        public void Delete(int roomId)
        {
            _roomRepo.Delete(roomId);
        }

        public async Task<IEnumerable<RoomDTO>> GetAllWithParametersAsync()
        {
            var roomParameters = await _roomRepo.GetAllWithParametersAsync();
            var roomParametersDTO = _mapper.Map<IEnumerable<RoomDTO>>(roomParameters);
            return roomParametersDTO;
        }

        public async Task<IEnumerable<RoomDTO>> GetAllFreeAsync()
        {
            var roomFree = await _roomRepo.GetAllFreeAsync();
            var roomFreeDTO = _mapper.Map<IEnumerable<RoomDTO>>(roomFree);
            return roomFreeDTO;
        }

        public int GetRoomIdByName(string roomName)
        {
            return _roomRepo.GetRoomIdByName(roomName);
        }
    }
}
