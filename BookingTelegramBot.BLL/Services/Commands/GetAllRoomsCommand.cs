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
    public class GetAllRoomsCommand : ICommand
    {
        private readonly RoomService _roomService;
        private readonly UserService _userService;

        public GetAllRoomsCommand(RoomService roomService, UserService userService)
        {
            _roomService = roomService;
            _userService = userService;
        }

        public string Name => @"/getallrooms";

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
                var rooms = await _roomService.GetAllAsync();
                foreach (var room in rooms)
                {
                    answer += $"\nId: {room.Id}, {room.Name}, {room.Description}, {room.NumberOfPersons}";
                }
                await client.SendTextMessageAsync(chatId, $"Список комнат:\n {answer}");
            }
            else
            {
                var rooms = await _roomService.GetAllAsync();
                foreach (var room in rooms)
                {
                    answer += $"\n{room.Name}, {room.Description}, {room.NumberOfPersons}";
                }
                await client.SendTextMessageAsync(chatId, $"Список комнат:\n {answer}");
            }
        }
    }
}
