using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.BLL.Infrastructure
{
    public class BotSettings
    {
        public string Token { get; set; } = "Token";
        public string Name { get; set; } = "Name";
        public string BaseUrl { get; set; } = "Ngrok";
    }
}
