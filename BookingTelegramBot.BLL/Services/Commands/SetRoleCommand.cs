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
    public class SetRoleCommand : ICommand
    {
        private readonly UserService _userService;

        public SetRoleCommand(UserService userService)
        {
            _userService = userService;
        }

        public string Name => @"/setrole";

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
                string[] userDescription = message.Text.Split(' ');

                var id = Convert.ToInt32(userDescription[1]);
                var roleId = Convert.ToInt32(userDescription[2]);
                var userTelegramId = Convert.ToInt32(userDescription[3]);

                var userToUpdate = new UserDTO() { Id = id, RoleId = roleId, TelegramId = userTelegramId};
                _userService.Update(userToUpdate);
                await _userService.SaveAsync();
                if (roleId == 1)
                {
                    await client.SendTextMessageAsync(chatId, $"Пользователь {userTelegramId} теперь admin");
                }
                else
                {
                    await client.SendTextMessageAsync(chatId, $"Пользователь {userTelegramId} теперь user");
                }
            }
            else
            {
                await client.SendTextMessageAsync(chatId, $"Вам не хватает доступа чтобы воспользоваться этой коммандой");
            }
        }
    }
}
