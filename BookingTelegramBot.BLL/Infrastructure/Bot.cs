using BookingTelegramBot.BLL.Interfaces;
using BookingTelegramBot.BLL.Services;
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
        private static List<ICommand> _commandsList = new List<ICommand>();
        private readonly BotSettings _settings;

        public Bot(BotSettings settings)
        {
            _settings = settings;
        }

        public IReadOnlyList<ICommand> Commands => _commandsList.AsReadOnly();

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
            _commandsList.Add(new StartCommand());
            //TODO: Add more commands

            var botClient = new TelegramBotClient(_settings.Token);

            string hook = $"{_settings.BaseUrl}api/message/postmessage";

            await botClient.SetWebhookAsync(hook);

            return botClient;
        }
    }
}
