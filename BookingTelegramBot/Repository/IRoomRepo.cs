﻿using BookingTelegramBot.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTelegramBot.Repository
{
    interface IRoomRepo
    {
        IEnumerable<Room> GetAll();
        Room GetRoomById(int roomId);
        void Insert(Room room);
        void Update(Room room);
        void Delete(int roomId);
        void Save();
    }
}
