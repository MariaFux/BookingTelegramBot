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
    public class UserReservationRepo : IUserReservationRepo
    {
        private readonly BookingRoomDbContext _context;

        public UserReservationRepo(BookingRoomDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserReservation>> GetAllAsync()
        {
            return await _context.UsersReservations.ToListAsync();
        }

        public async Task<UserReservation> GetUserReservationByIdAsync(int userReservationId)
        {
            return await _context.UsersReservations.FindAsync(userReservationId);
        }

        public void Insert(UserReservation userReservation)
        {
            _context.UsersReservations.Add(userReservation);
        }

        public void Update(UserReservation userReservation)
        {
            _context.Entry(userReservation).State = EntityState.Modified;
        }

        public void Delete(int userReservationId)
        {
            UserReservation userReservation = _context.UsersReservations.Find(userReservationId);
            _context.UsersReservations.Remove(userReservation);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
