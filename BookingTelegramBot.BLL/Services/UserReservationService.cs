using BookingTelegramBot.BLL.Interfaces;
using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.BLL.Services
{
    public class UserReservationService : IUserReservationService
    {
        public UserReservationRepo userReservationRepo;

        public UserReservationService(UserReservationRepo userReservationRepo)
        {
            this.userReservationRepo = userReservationRepo;
        }

        public IEnumerable<UserReservation> GetAll()
        {
            return userReservationRepo.GetAll();
        }

        public UserReservation GetUserReservationById(int userReservationId)
        {
            return userReservationRepo.GetUserReservationById(userReservationId);
        }

        public void Insert(UserReservation userReservation)
        {
            userReservationRepo.Insert(userReservation);
        }

        public void Update(UserReservation userReservation)
        {
            userReservationRepo.Update(userReservation);
        }

        public void Delete(int userReservationId)
        {
            userReservationRepo.Delete(userReservationId);
        }

        public void Save()
        {
            userReservationRepo.Save();
        }
    }
}
