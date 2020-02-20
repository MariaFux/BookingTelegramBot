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
        public BookingRoomDbContext context;

        public UserReservationRepo(BookingRoomDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<UserReservation>> GetAll()
        {
            return await context.UsersReservations.ToListAsync();
        }

        public async Task<UserReservation> GetUserReservationById(int userReservationId)
        {
            return await context.UsersReservations.FindAsync(userReservationId);
        }

        public void Insert(UserReservation userReservation)
        {
            context.UsersReservations.Add(userReservation);
        }

        public void Update(UserReservation userReservation)
        {
            context.Entry(userReservation).State = EntityState.Modified;
        }

        public void Delete(int userReservationId)
        {
            UserReservation userReservation = context.UsersReservations.Find(userReservationId);
            context.UsersReservations.Remove(userReservation);
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
