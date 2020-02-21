using BookingTelegramBot.DAL.EF;
using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.DAL.Repositories
{
    public class UserRepo : IUserRepo
    {
        public BookingRoomDbContext context;

        public UserRepo(BookingRoomDbContext context)
        {
            this.context = context;
        }

        public async Task<User> FindByUserIdAsync(int userId)
        {
            return await context.Users.FindAsync(userId);
        }
    }
}
