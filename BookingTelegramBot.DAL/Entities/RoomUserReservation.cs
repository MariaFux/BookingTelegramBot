using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.DAL.Entities
{
    public class RoomUserReservation
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public int UserReservationId { get; set; }
        public UserReservation UserReservation { get; set; }
    }
}
