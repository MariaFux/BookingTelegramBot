using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BookingTelegramBot.BLL.Interfaces
{
    public interface ICommand
    {
        public string Name { get; }
        public Task Execute(Message message, TelegramBotClient client);
        public bool Contains(Message message);
    }
}
