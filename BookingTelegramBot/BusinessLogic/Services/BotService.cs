using BookingTelegramBot.Configurations;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace BookingTelegramBot.BusinessLogic.Services
{
    public class BotService : IBotService
    {
        private readonly BotConfiguration _config;

        public BotService(IOptions<BotConfiguration> config, TelegramBotClient client)
        {
            _config = config.Value;
            Client = client;
        }

        public TelegramBotClient Client { get; }
    }
}
