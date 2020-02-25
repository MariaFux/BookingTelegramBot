using BookingTelegramBot.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.DAL.Interfaces
{
    public interface IUserRepo
    {
        Task<User> FindByUserIdAsync(int userId); 
        Task<User> GetUserAsync(); 
    }
}
