using BookingTelegramBot.BLL.Interfaces;
using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.BLL.Services
{
    public class RoomService : IRoomService
    {
        public RoomRepo roomRepo;

        public RoomService(RoomRepo roomRepo)
        {
            this.roomRepo = roomRepo;
        }

        public IEnumerable<Room> GetAll()
        {
            return roomRepo.GetAll();
        }

        public Room GetRoomById(int roomId)
        {
            return roomRepo.GetRoomById(roomId);
        }

        public void Insert(Room room)
        {
            roomRepo.Insert(room);
        }

        public void Update(Room room)
        {
            roomRepo.Update(room);
        }

        public void Delete(int roomId)
        {
            roomRepo.Delete(roomId);
        }

        public void Save()
        {
            roomRepo.Save();
        }

        public IEnumerable<Room> GetAllWithParameters()
        {
            return roomRepo.GetAllWithParameters();
        }
    }
}
