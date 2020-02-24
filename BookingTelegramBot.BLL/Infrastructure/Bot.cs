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
        private static TelegramBotClient botClient;
        private static List<ICommand> commandsList;

        public static IReadOnlyList<ICommand> Commands => commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (botClient != null)
            {
                return botClient;
            }

            commandsList = new List<ICommand>();
            commandsList.Add(new StartCommand());
            //TODO: Add more commands

            botClient = new TelegramBotClient(BotSettings.Token);
            string hook = string.Format(BotSettings.Url, "api/message/postmessage");
            await botClient.SetWebhookAsync(hook);
            return botClient;
        }
    }
}
