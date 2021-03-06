﻿using BookingTelegramBot.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTelegramBot.Repository
{
    interface IUserReservationRepo
    {
        IEnumerable<UserReservation> GetAll();
        UserReservation GetUserReservationById(int userReservationId);
        void Insert(UserReservation userReservation);
        void Update(UserReservation userReservation);
        void Delete(int userReservationId);
        void Save();
    }
}
