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
        public string AnotherDescription { get; set; }

        public ICollection<ParameterDTO> Parameters { get; set; }
        public ICollection<UserReservationDTO> UsersReservations { get; set; }

        public RoomDTO()
        {
            Parameters = new List<ParameterDTO>();
            UsersReservations = new List<UserReservationDTO>();
        }
    }
}
