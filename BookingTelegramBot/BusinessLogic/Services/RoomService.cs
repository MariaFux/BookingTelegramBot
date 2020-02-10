using BookingTelegramBot.Repository;
using BookingTelegramBot.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTelegramBot.BusinessLogic.Services
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

        public Room GetRoomByID(int roomID)
        {
            return roomRepo.GetRoomByID(roomID);
        }

        public void Inser(Room room)
        {
            roomRepo.Inser(room);
        }        

        public void Update(Room room)
        {
            roomRepo.Update(room);
        }

        public void Delete(int roomID)
        {
            roomRepo.Delete(roomID);
        }

        public void Save()
        {
            roomRepo.Save();
        }
    }
}
