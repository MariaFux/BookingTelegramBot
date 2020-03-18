using AutoMapper;
using BookingTelegramBot.BLL.DTO;
using BookingTelegramBot.BLL.Services;
using BookingTelegramBot.DAL.EF;
using BookingTelegramBot.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookingTelegramBot.Tests
{
    public class RoomServiceTests
    {
        private IMapper _mapper;
        
        public RoomServiceTests(IMapper mapper)
        {
            _mapper = mapper;
        }

        [Fact]
        public async Task GetRoomByIdAsync()
        {
            var options = new DbContextOptionsBuilder<BookingRoomDbContext>().UseInMemoryDatabase(databaseName: "BookingRoom").Options;

            using (var context = new BookingRoomDbContext(options))
            {
                var repo = new RoomRepo(context);
                var room = await repo.GetRoomByIdAsync(1);

                var mockMapper = _mapper.Map<RoomDTO>(room);

                var service = new RoomService(repo, _mapper);
                var result = await service.GetRoomByIdAsync(1);

                Assert.Equal(mockMapper.Name, result.Name);
                Assert.Equal(mockMapper.NumberOfPersons, result.NumberOfPersons);
                Assert.Equal(mockMapper.RoomParameters.Count, result.RoomParameters.Count);
            }
        }   
    }    
}
