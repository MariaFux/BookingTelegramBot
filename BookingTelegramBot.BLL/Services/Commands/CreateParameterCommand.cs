using BookingTelegramBot.BLL.DTO;
using BookingTelegramBot.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BookingTelegramBot.BLL.Services.Commands
{
    public class CreateParameterCommand : ICommand
    {
        private readonly ParameterService _parameterService;
        private readonly UserService _userService;

        public CreateParameterCommand(ParameterService parameterService, UserService userService)
        {
            _parameterService = parameterService;
            _userService = userService;
        }

        public string Name => @"/createparameter";

        public bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;
            return message.Text.Contains(this.Name);
        }

        public async Task Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;

            var telegramId = message.From.Id;
            var user = await _userService.FindByTelegramIdAsync(telegramId);
            if (user != null && user.Role.UserRole.ToString() == "admin")
            {
                string[] parameterName = message.Text.Split(' ');

                var name = parameterName[1];

                var parameterToAdd = new ParameterDTO() { NameOfParameter = name };

                _parameterService.Insert(parameterToAdd);
                await _parameterService.SaveAsync();

                await client.SendTextMessageAsync(chatId, $"Добавлен параметер {name}");
            }
            else
            {
                await client.SendTextMessageAsync(chatId, $"Вам не хватает доступа чтобы воспользоваться этой коммандой");
            }
        }
    }
}
