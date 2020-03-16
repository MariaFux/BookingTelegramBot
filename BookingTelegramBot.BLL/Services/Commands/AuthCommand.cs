using BookingTelegramBot.BLL.DTO;
using BookingTelegramBot.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BookingTelegramBot.BLL.Services.Commands
{
    public class AuthCommand : ICommand
    {
        private readonly UserService _userService;

        public AuthCommand(UserService userService)
        {
            _userService = userService;
        }

        public string Name => @"/auth";

        public bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;
            return message.Text.Contains(this.Name);
        }

        public async Task Execute(Message message, TelegramBotClient client)
        {
            var answer = @"Теперь вы можете использовать полный перечень команд:
/free - Позволяет найти свободные комнаты исходя из введенных данных(дата, время, количество человек)
/getallrooms - Список всех доступных комнат
/order - Забронировать подходящую комнату";

            var chatId = message.Chat.Id;
            var telegramId = message.From.Id;

            var user = await _userService.FindByTelegramIdAsync(telegramId);

            if (user != null && user.Role.UserRole.ToString() == "admin")
            {
                answer += "\n\n*Admin commands:*";
                answer += "\n/createroom - Позволяет добавить новую комнату";
                answer += "\n/updateroom - Позволяет изменить существующую комнату";
                answer += "\n/deleteroom - Позволяет удалить существующую комнату";
                answer += "\n/getallusers - Список всех пользователей";
                answer += "\n/setrole - Позволяет изменить роль пользователя";
                answer += "\n/createparameter - Позволяет добавить новый параметер";
                answer += "\n/updateparameter - Позволяет изменить имеющийся параметер";
                answer += "\n/getallparameters - Список всех параметров";
                answer += "\n/deleteparameter - Позволяет удалить параметер";
                answer += "\n/allroomsparameters - Список всех комнат с параметрами";
                answer += "\n/addroomsparameters - Позволяет добавить параметры к комнате";
                await client.SendTextMessageAsync(chatId, answer, ParseMode.Markdown);
            }
            else if (user != null && user.Role.UserRole.ToString() == "user")
            {
                await client.SendTextMessageAsync(chatId, answer);
            }
            else
            {
                var userDTO = new UserDTO() { TelegramId = telegramId, RoleId = 2 };
                _userService.Insert(userDTO);
                await _userService.SaveAsync();
                await client.SendTextMessageAsync(chatId, answer);
            }
        }
    }
}
