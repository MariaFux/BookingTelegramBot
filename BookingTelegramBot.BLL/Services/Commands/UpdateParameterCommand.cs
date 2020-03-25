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
    public class UpdateParameterCommand : ICommand
    {
        private readonly ParameterService _parameterService;
        private readonly UserService _userService;

        public UpdateParameterCommand(ParameterService parameterService, UserService userService)
        {
            _parameterService = parameterService;
            _userService = userService;
        }

        public string Name => @"/updateparameter";

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
                string[] parameterDescription = message.Text.Split(',');

                var id = Convert.ToInt32(parameterDescription[1].Trim());
                var name = parameterDescription[2].Trim();

                var parameterToUpdate = new ParameterDTO() { Id = id, NameOfParameter = name };

                _parameterService.Update(parameterToUpdate);
                await _parameterService.SaveAsync();

                await client.SendTextMessageAsync(chatId, $"Изменен параметер: {name}");
            }
            else
            {
                await client.SendTextMessageAsync(chatId, $"Вам не хватает доступа чтобы воспользоваться этой коммандой");
            }
        }
    }
}
