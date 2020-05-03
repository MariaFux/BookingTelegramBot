using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.BLL.DTO
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPersons { get; set; }
        public List<RoomParameterDTO> RoomParameters { get; set; }
        public List<RoomUserReservationDTO> RoomUserReservations { get; set; }
    }
}
