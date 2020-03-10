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
    public class GetAllUsersCommand : ICommand
    {
        private readonly UserService _userService;

        public GetAllUsersCommand(UserService userService)
        {
            _userService = userService;
        }

        public string Name => @"/getallusers";

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
                var users = await _userService.GetAllAsync();
                foreach (var u in users)
                {
                    answer += $"\nId: {u.Id}, {u.TelegramId}, {u.Role.UserRole} - RoleId: {u.RoleId}";
                }
                await client.SendTextMessageAsync(chatId, $"Список пользователей:\n {answer}");
            }
            else
            {
                await client.SendTextMessageAsync(chatId, $"Вам не хватает доступа чтобы воспользоваться этой коммандой");
            }
        }
    }
}
