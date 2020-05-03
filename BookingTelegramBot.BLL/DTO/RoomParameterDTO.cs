using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.BLL.DTO
{
    public class RoomParameterDTO
    {
        public int RoomId { get; set; }
        public RoomDTO Room { get; set; }

        public int ParameterId { get; set; }
        public ParameterDTO Parameter { get; set; }
    }
}
