﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public int TelegramId { get; set; }

        public int? RoleId { get; set; }
        public RoleDTO Role { get; set; }
    }
}
