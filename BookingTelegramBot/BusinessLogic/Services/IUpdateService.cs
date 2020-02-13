using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace BookingTelegramBot.BusinessLogic.Services
{
    interface IUpdateService
    {
        Task EchoAsync(Update update);
    }
}
