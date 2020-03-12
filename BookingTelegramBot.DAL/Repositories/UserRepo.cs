using BookingTelegramBot.DAL.EF;
using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.Include(u => u.Role).ToListAsync();
        }

        public async Task<User> FindByTelegramIdAsync(int telegramId)
        {
            return await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.TelegramId == telegramId);
        }

        public void Insert(User user)
        {
            _context.Users.Add(user);
        }

        public void Update(User user)
        {
            var attached = _context.Users.Local.FirstOrDefault(x => x.Id == user.Id);

            if(attached != null)
            {
                _context.Entry(attached).CurrentValues.SetValues(user);
            }
            else
            {
                _context.Entry(user).State = EntityState.Modified;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
