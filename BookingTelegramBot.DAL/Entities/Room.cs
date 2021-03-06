﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.DAL.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPersons { get; set; }
        public ICollection<RoomParameter> RoomParameters { get; set; } = new List<RoomParameter>();
        public ICollection<RoomUserReservation> RoomUserReservations { get; set; } = new List<RoomUserReservation>();
    }
}
