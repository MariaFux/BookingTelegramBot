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
    public class UserServiceV2 : IUserService
    {
        private readonly UserRepoV2 _userRepo;
        private readonly IMapper _mapper;

        public UserServiceV2(UserRepoV2 userRepo, IMapper mapper)
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
    }
}
