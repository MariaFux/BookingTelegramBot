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
    }
}
