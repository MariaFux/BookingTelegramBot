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

        public BotService(IOptions<BotConfiguration> config)
        {
            _config = config.Value;
            Client = new TelegramBotClient(_config.Token);
        }

        public TelegramBotClient Client { get; }
    }
}
