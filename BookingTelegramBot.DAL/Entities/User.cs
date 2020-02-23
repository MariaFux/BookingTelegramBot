using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookingTelegramBot.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string TelegramName { get; set; }
    }
}
