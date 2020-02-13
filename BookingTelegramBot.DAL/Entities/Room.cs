using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.DAL.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AnotherDescription { get; set; }

        public ICollection<Parameter> Parameters { get; set; }
        public ICollection<UserReservation> UsersReservations { get; set; }

        public Room()
        {
            var Parameters = new List<Parameter>();
            var UsersReservations = new List<UserReservation>();
        }
    }
}
