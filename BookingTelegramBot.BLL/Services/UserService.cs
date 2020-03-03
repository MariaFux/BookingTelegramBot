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
        private readonly UserRepo _userRepo;
        private readonly IMapper _mapper;

        public UserService(UserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<UserDTO> FindByUserIdAsync(int userId)
        {
            var user = await _userRepo.FindByUserIdAsync(userId);
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task<UserDTO> GetUserAsync(string name)
        {
            var user = await _userRepo.GetUserAsync(name);
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }
    }
}
