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
    public class UserService : IUserService
    {
        private readonly UserRepo _userRepo;
        private readonly IMapper _mapper;

        public UserService(UserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var users = await _userRepo.GetAllAsync();
            var usersDTO = _mapper.Map<IEnumerable<UserDTO>>(users);
            return usersDTO;
        }

        public async Task<UserDTO> FindByTelegramIdAsync(int telegramId)
        {
            var user = await _userRepo.FindByTelegramIdAsync(telegramId);
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public void Insert(UserDTO userDTO)
        {
            _userRepo.Insert(_mapper.Map<User>(userDTO));
        }

        public void Update(UserDTO user)
        {
            _userRepo.Update(_mapper.Map<User>(user));
        }

        public async Task SaveAsync()
        {
            await _userRepo.SaveAsync();
        }        
    }
}
