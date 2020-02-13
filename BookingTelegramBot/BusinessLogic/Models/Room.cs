using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTelegramBot.BusinessLogic.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Parameter> Parameters { get; set; }
        public ICollection<UserReservation> UsersReservations { get; set; }

        public Room()
        {
            Parameters = new List<Parameter>();
            UsersReservations = new List<UserReservation>();
        }
    }
}
