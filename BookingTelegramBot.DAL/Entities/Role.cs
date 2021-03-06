﻿using BookingTelegramBot.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.DAL.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public Roles UserRole { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
