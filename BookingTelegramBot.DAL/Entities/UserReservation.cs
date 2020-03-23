using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookingTelegramBot.DAL.Entities
{
    public class UserReservation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TelegramId { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public ICollection<RoomUserReservation> RoomUserReservations { get; set; } = new List<RoomUserReservation>();
    }
}
