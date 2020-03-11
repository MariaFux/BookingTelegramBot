using BookingTelegramBot.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.DAL.Interfaces
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> FindByTelegramIdAsync(int telegramId); 
        void Insert(User user);
        void Update(User user);
        Task SaveAsync();
    }
}
