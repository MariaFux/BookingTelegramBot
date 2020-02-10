using BookingTelegramBot.Repository;
using BookingTelegramBot.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTelegramBot.BusinessLogic.Services
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

        public UserReservation GetUserReservationByID(int userReservationID)
        {
            return userReservationRepo.GetUserReservationByID(userReservationID);
        }

        public void Insert(UserReservation userReservation)
        {
            userReservationRepo.Insert(userReservation);
        }        

        public void Update(UserReservation userReservation)
        {
            userReservationRepo.Update(userReservation);
        }

        public void Delete(int userReservationID)
        {
            userReservationRepo.Delete(userReservationID);
        }

        public void Save()
        {
            userReservationRepo.Save();
        }
    }
}
