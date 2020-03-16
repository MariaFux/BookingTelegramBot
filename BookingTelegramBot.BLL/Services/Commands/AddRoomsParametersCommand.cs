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
    public class AddRoomsParametersCommand : ICommand
    {
        private readonly RoomParameterService _roomParameterService;
        private readonly RoomService _roomService;
        private readonly ParameterService _parameterService;
        private readonly UserService _userService;

        public AddRoomsParametersCommand(RoomParameterService roomParameterService, UserService userService, RoomService roomService, ParameterService parameterService)
        {
            _roomParameterService = roomParameterService;
            _userService = userService;
            _roomService = roomService;
            _parameterService = parameterService;
        }

        public string Name => @"/addroomsparameters";

        public bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;
            return message.Text.Contains(this.Name);
        }

        public async Task Execute(Message message, TelegramBotClient client)
        {
            var answer = ""; 
            var chatId = message.Chat.Id;

            var telegramId = message.From.Id;
            var user = await _userService.FindByTelegramIdAsync(telegramId);
            if (user != null && user.Role.UserRole.ToString() == "admin")
            {
                string[] roomParameters = message.Text.Split(' ');

                var roomId = Convert.ToInt32(roomParameters[1]);
                var parameters = roomParameters[2..roomParameters.Length];

                foreach(var param in parameters)
                {
                    var parameterId = Convert.ToInt32(param);
                    var roomParameterToInsert = new RoomParameterDTO() { RoomId = roomId, ParameterId = parameterId };
                    _roomParameterService.Insert(roomParameterToInsert);
                    await _roomParameterService.SaveAsync();

                    var parameter = await _parameterService.GetParameterByIdAsync(parameterId);
                    answer += parameter.NameOfParameter + " ";
                }

                var room = await _roomService.GetRoomByIdAsync(roomId);

                await client.SendTextMessageAsync(chatId, $"К комнате {room.Name} добавлены параметры {answer}");
            }
            else
            {
                await client.SendTextMessageAsync(chatId, $"Вам не хватает доступа чтобы воспользоваться этой коммандой");
            }
        }
    }
}
