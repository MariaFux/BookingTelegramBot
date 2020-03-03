using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookingTelegramBot.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int TelegramId { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
}
