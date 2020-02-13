﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BookingTelegramBot.BusinessLogic.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly IBotService botService;

        public UpdateService(IBotService botService)
        {
            this.botService = botService;
        }

        public async Task EchoAsync(Update update)
        {
            if (update.Type != UpdateType.Message)
                return;

            var message = update.Message;

            switch (message.Type)
            {
                case MessageType.Text:
                    // Echo each Message
                    await botService.Client.SendTextMessageAsync(message.Chat.Id, message.Text);
                    break;
            }
        }
    }
}
