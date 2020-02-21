using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.DAL.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
