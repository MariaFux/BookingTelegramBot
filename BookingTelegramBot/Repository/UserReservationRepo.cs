using BookingTelegramBot.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTelegramBot.Repository
{
    public class UserReservationRepo : IUserReservationRepo
    {
        public BookingRoomDbContext context;              

        public IEnumerable<UserReservation> GetAll()
        {
            return context.UsersReservations.ToList();
        }

        public UserReservation GetUserReservationByID(int userReservationID)
        {
            return context.UsersReservations.Find(userReservationID);
        }

        public void Insert(UserReservation userReservation)
        {
            context.UsersReservations.Add(userReservation);
        }        

        public void Update(UserReservation userReservation)
        {
            context.Entry(userReservation).State = EntityState.Modified;
        }

        public void Delete(int userReservationID)
        {
            UserReservation userReservation = context.UsersReservations.Find(userReservationID);
            context.UsersReservations.Remove(userReservation);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
