using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.DAL.Entities
{
    public class UserReservation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public ICollection<RoomUserReservation> RoomUserReservations { get; set; }

        public UserReservation()
        {
            RoomUserReservations = new List<RoomUserReservation>();
        }
    }
}
