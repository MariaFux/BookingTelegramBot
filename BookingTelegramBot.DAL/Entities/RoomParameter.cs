using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.DAL.Entities
{
    public class RoomParameter
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public int ParameterId { get; set; }
        public Parameter Parameter { get; set; }
    }
}
