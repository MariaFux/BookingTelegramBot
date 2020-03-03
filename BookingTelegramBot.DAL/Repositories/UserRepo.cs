using BookingTelegramBot.DAL.EF;
using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.DAL.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly BookingRoomDbContext _context;

        public UserRepo(BookingRoomDbContext context)
        {
            _context = context;
        }

        public async Task<User> FindByUserIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<User> GetUserAsync(string name)
        {
            return await _context.Users.Include(r => r.Role).FirstOrDefaultAsync(u => u.TelegramName == name);
        }
    }
}
