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
    public class DeleteRoomCommand : ICommand
    {
        private readonly RoomService _roomService;
        private readonly UserService _userService;

        public DeleteRoomCommand(RoomService roomService, UserService userService)
        {
            _roomService = roomService;
            _userService = userService;
        }

        public string Name => @"/deleteroom";

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
                string[] roomId = message.Text.Split(',');

                var id = Convert.ToInt32(roomId[1].Trim());

                _roomService.Delete(id);
                await _roomService.SaveAsync();
                await client.SendTextMessageAsync(chatId, $"Удаление прошло успешно!");
            }
            else
            {
                await client.SendTextMessageAsync(chatId, $"Вам не хватает доступа чтобы воспользоваться этой коммандой");
            }
        }
    }
}
