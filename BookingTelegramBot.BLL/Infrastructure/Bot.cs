using BookingTelegramBot.BLL.Interfaces;
using BookingTelegramBot.BLL.Services;
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
        private static List<ICommand> _commandsList = new List<ICommand>();
        private readonly BotSettings _settings;
        private readonly AuthCommand _authCommand;
        private readonly FreeCommand _freeCommand;
        private readonly CreateCommand _createCommand;

        public Bot(IOptions<BotSettings> settings, AuthCommand authCommand, FreeCommand freeCommand, CreateCommand createCommand)
        {
            _settings = settings.Value;
            _authCommand = authCommand;
            _freeCommand = freeCommand;
            _createCommand = createCommand;
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
            _commandsList.Add(_authCommand);
            _commandsList.Add(_freeCommand);
            _commandsList.Add(_createCommand);
            //TODO: Add more commands

            var botClient = new TelegramBotClient(_settings.Token);

            string hook = $"{_settings.BaseUrl}api/message/postmessage";

            await botClient.SetWebhookAsync(hook);

            return botClient;
        }
    }
}
