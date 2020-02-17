using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.DAL.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AnotherDescription { get; set; }
        public ICollection<RoomParameter> RoomParameters { get; set; }
        public ICollection<RoomUserReservation> RoomUserReservations { get; set; }

        public Room()
        {
            RoomParameters = new List<RoomParameter>();
            RoomUserReservations = new List<RoomUserReservation>();
        }
    }
}
