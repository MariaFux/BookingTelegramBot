﻿using BookingTelegramBot.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.DAL.Interfaces.v2
{
    interface IRoomRepo
    {
        Task<IEnumerable<Room>> GetAllAsync();
        Task<Room> GetRoomByIdAsync(int roomId);
        void Insert(Room room);
        void Update(Room room);
        void Delete(int roomId);
        Task<IEnumerable<Room>> GetAllWithParametersAsync();
        Task<IEnumerable<Room>> GetAllFreeAsync();
        int GetRoomIdByName(string roomName);
    }
}
