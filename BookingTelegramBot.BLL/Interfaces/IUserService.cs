using BookingTelegramBot.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.BLL.Interfaces
{
    interface IUserService
    {
        Task<UserDTO> FindByUserIdAsync(int userId);
        Task<UserDTO> GetUserAsync(string name);
    }
}
