using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.BLL.DTO
{
    public class RoomUserReservationDTO
    {
        public int RoomId { get; set; }
        public RoomDTO Room { get; set; }

        public int UserReservationId { get; set; }
        public UserReservationDTO UserReservation { get; set; }
    }
}
