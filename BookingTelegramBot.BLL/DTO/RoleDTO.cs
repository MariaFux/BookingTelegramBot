using BookingTelegramBot.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.BLL.DTO
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public Roles UserRole { get; set; }
        public List<UserDTO> Users { get; set; }
    }
}
