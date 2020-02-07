using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTelegramBot.Repository.Models
{
    public class Parameter
    {
        public int ID { get; set; }
        public int NumberOfPersons { get; set; }
        public bool Projector { get; set; }
        public bool ProjectorControlPanel { get; set; }
        public bool Display { get; set; }
        public bool Computer { get; set; }
        public bool Microphone { get; set; }
        public bool Camera { get; set; }
        public bool Board { get; set; }
        public int CountOfTable { get; set; }
        public int CountOfChairs { get; set; }
        public bool Phone { get; set; }

        public int? RoomId { get; set; }
        public Room Room { get; set; }
    }
}
