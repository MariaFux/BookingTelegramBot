using AutoMapper;
using BookingTelegramBot.BLL.DTO;
using BookingTelegramBot.BLL.Services;
using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookingTelegramBot.Tests
{
    public class RoomServiceTests
    {
        private readonly RoomRepo _roomRepo;
        private readonly IMapper _mapper;
        
        public RoomServiceTests(RoomRepo roomRepo, IMapper mapper)
        {
            _roomRepo = roomRepo;
            _mapper = mapper;
        }

        [Fact]
        public async Task GetRoomByIdAsync()
        {
            var room = new Room() { Id = 1, Name = "Room 1", Description = "First", NumberOfPersons = 10 };
            var expectedRoom = _mapper.Map<RoomDTO>(room);

            var service = new RoomService(_roomRepo, _mapper);
            var result = await service.GetRoomByIdAsync(1);            

            Assert.Equal(expectedRoom.Name, result.Name);
            Assert.Equal(expectedRoom.NumberOfPersons, result.NumberOfPersons);
            Assert.Equal(expectedRoom.RoomParameters.Count, result.RoomParameters.Count);
        }
    }    
}
