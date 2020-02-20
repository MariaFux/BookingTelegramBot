using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.BLL.DTO
{
    public class UserReservationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
    }
}
