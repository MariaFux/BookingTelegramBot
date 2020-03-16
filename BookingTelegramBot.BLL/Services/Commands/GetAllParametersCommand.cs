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
    public class GetAllParametersCommand : ICommand
    {
        private readonly ParameterService _parameterService;
        private readonly UserService _userService;

        public GetAllParametersCommand(ParameterService parameterService, UserService userService)
        {
            _parameterService = parameterService;
            _userService = userService;
        }

        public string Name => @"/getallparameters";

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

            var answer = "";

            if (user != null && user.Role.UserRole.ToString() == "admin")
            {
                var parameters = await _parameterService.GetAllAsync();
                foreach (var parameter in parameters)
                {
                    answer += $"\nId: {parameter.Id}, {parameter.NameOfParameter}";
                }
                await client.SendTextMessageAsync(chatId, $"Список параметров:\n {answer}");
            }
            else
            {
                await client.SendTextMessageAsync(chatId, $"Вам не хватает доступа чтобы воспользоваться этой коммандой");
            }
        }
    }
}
