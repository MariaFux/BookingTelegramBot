using BookingTelegramBot.BLL.DTO;
using BookingTelegramBot.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BookingTelegramBot.BLL.Services
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
            var chatId = message.Chat.Id;
            var telegramId = message.From.Id;
            var user = await _userService.FindByTelegramIdAsync(telegramId);
            if (user != null)
            {
                await client.SendTextMessageAsync(chatId, @"Теперь вы можете использовать полный перечень команд:
/free - Позволяет найти свободные комнаты исходя из введенных данных(дата, время, количество человек)
/all - Список всех доступных комнат
/order - Забронировать подходящую комнату");
            }
            else
            {
                var userDTO = new UserDTO() { TelegramId = telegramId, RoleId = 2 };
                _userService.Insert(userDTO);
                await _userService.SaveAsync();
                await client.SendTextMessageAsync(chatId, "Теперь вы можете использовать полный перечень команд:" +
                    "/free - Позволяет найти свободные комнаты исходя из введенных данных(дата, время, количество человек)" +
                    "/all - Список всех доступных комнат" +
                    "/order - Забронировать подходящую комнату");
            }
        }
    }
}
