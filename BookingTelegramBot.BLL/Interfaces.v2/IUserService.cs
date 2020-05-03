using BookingTelegramBot.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.BLL.Interfaces.v2
{
    interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO> FindByTelegramIdAsync(int telegramId);
        void Insert(UserDTO userDTO);
        void Update(UserDTO userDTO);
    }
}
