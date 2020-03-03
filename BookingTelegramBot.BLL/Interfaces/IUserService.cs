using BookingTelegramBot.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.BLL.Interfaces
{
    interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO> FindByTelegramIdAsync(int telegramId);
        void Insert(UserDTO userDTO);
        Task SaveAsync();
    }
}
