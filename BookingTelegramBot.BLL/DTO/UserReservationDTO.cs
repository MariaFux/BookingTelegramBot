using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.BLL.DTO
{
    public class UserReservationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TelegramId { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public List<RoomUserReservationDTO> RoomUserReservations { get; set; }
    }
}
