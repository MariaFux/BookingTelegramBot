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
    public class AllRoomsParametersCommand : ICommand
    {
        private readonly RoomService _roomService;
        private readonly UserService _userService;

        public AllRoomsParametersCommand(RoomService roomService, UserService userService)
        {
            _roomService = roomService;
            _userService = userService;
        }

        public string Name => @"/allroomsparameters";

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
                var roomsParameters = await _roomService.GetAllWithParametersAsync();
                foreach (var room in roomsParameters)
                {
                    answer += $"\nId: {room.Id}, {room.Name}, {room.Description}, {room.NumberOfPersons}";
                    answer += "\n*Parameters:*";
                    foreach (var parameter in room.RoomParameters)
                    {                        
                        answer += $"\nId: {parameter.ParameterId}, {parameter.Parameter.NameOfParameter}";
                    }
                    answer += "\n";
                }
                await client.SendTextMessageAsync(chatId, $"Список комнат c параметрами:\n {answer}", ParseMode.Markdown);
            }
            else
            {
                var roomsParameters = await _roomService.GetAllWithParametersAsync();
                foreach (var room in roomsParameters)
                {
                    answer += $"\n{room.Name}, {room.Description}, {room.NumberOfPersons}";
                    answer += "\n*Parameters:*";
                    foreach (var parameter in room.RoomParameters)
                    {
                        answer += $"\n{parameter.Parameter.NameOfParameter}";
                    }
                    answer += "\n";
                }
                await client.SendTextMessageAsync(chatId, $"Список комнат c параметрами:\n {answer}", ParseMode.Markdown);
            }
        }
    }
}
