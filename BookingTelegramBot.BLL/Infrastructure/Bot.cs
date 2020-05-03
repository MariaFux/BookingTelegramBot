using BookingTelegramBot.BLL.Interfaces;
using BookingTelegramBot.BLL.Services.Commands;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace BookingTelegramBot.BLL.Infrastructure
{
    public class Bot
    {
        private static TelegramBotClient _botClient;
        private readonly CommandsList _commandsList;
        private readonly BotSettings _settings;

        public Bot(IOptions<BotSettings> settings, CommandsList commandsList)
        {
            _settings = settings.Value;
            _commandsList = commandsList;
        }

        public IReadOnlyList<ICommand> Commands => _commandsList.Commands;

        public async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (_botClient != null)
            {
                return _botClient;
            }

            _botClient = await BotInitialization();            

            return _botClient;
            
        }

        private async Task<TelegramBotClient> BotInitialization()
        {
            var botClient = new TelegramBotClient(_settings.Token);

            string hook = $"{_settings.BaseUrl}api/message/postmessage";

            await botClient.SetWebhookAsync(hook);

            return botClient;
        }
    }
}
