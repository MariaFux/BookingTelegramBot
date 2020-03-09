using BookingTelegramBot.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BookingTelegramBot.BLL.Services
{
    public class MessageService
    {
        private readonly Bot _bot;
        public static int Token { get; set; }

        public MessageService(Bot bot)
        {
            _bot = bot;
            _bot.GetBotClientAsync().Wait();
        }

        public async Task MessageHandling(Update update)
        {
            Token = update.Message.From.Id;
            bool isACommand = false;

            var commands = _bot.Commands;
            var message = update.Message;
            var botClient = await _bot.GetBotClientAsync();

            foreach (var command in commands)
            {
                if (command.Contains(message))
                {
                    await command.Execute(message, botClient);
                    isACommand = true;
                    break;
                }
            }

            if (message?.Type == MessageType.Text && !isACommand)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, message.Text);
            }
        }
    }
}
