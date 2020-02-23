using AutoMapper;
using BookingTelegramBot.BLL.DTO;
using BookingTelegramBot.BLL.Interfaces;
using BookingTelegramBot.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.BLL.Services
{
    public class UserService : IUserService
    {
        public UserRepo userRepo;
        private readonly IMapper mapper;

        public UserService(UserRepo userRepo, IMapper mapper)
        {
            this.userRepo = userRepo;
            this.mapper = mapper;
        }

        public async Task<UserDTO> FindByUserIdAsync(int userId)
        {
            var user = await userRepo.FindByUserIdAsync(userId);
            var userDTO = mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task<UserDTO> GetUserAsync()
        {
            var user = await userRepo.GetUserAsync();
            var userDTO = mapper.Map<UserDTO>(user);
            return userDTO;
        }
    }
}
