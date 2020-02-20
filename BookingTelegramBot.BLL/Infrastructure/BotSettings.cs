using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.BLL.Infrastructure
{
    public static class BotSettings
    {
        public static string Token { get; set; } = "Token";
        public static string Name { get; set; } = "Name";
        public static string Url { get; set; } = "Ngrok/{0}";
    }
}
