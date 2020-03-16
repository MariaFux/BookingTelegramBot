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
    public class DeleteRoomParameterCommand : ICommand
    {
        private readonly RoomParameterService _roomParameterService;
        private readonly RoomService _roomService;
        private readonly ParameterService _parameterService;
        private readonly UserService _userService;

        public DeleteRoomParameterCommand(RoomParameterService roomParameterService, UserService userService, RoomService roomService, ParameterService parameterService)
        {
            _roomParameterService = roomParameterService;
            _userService = userService;
            _roomService = roomService;
            _parameterService = parameterService;
        }

        public string Name => @"/roomsparametersdelete";

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
                string[] roomParameter = message.Text.Split(' ');

                var roomId = Convert.ToInt32(roomParameter[1]);
                var parameterId = Convert.ToInt32(roomParameter[2]);

                var roomParameterToDelete = new RoomParameterDTO() { RoomId = roomId, ParameterId = parameterId };

                _roomParameterService.Delete(roomParameterToDelete);
                await _roomParameterService.SaveAsync();

                var parameter = await _parameterService.GetParameterByIdAsync(parameterId);
                var room = await _roomService.GetRoomByIdAsync(roomId);

                await client.SendTextMessageAsync(chatId, $"Удаление параметра {parameter.NameOfParameter} из комнаты {room.Name} прошло успешно!");
            }
            else
            {
                await client.SendTextMessageAsync(chatId, $"Вам не хватает доступа чтобы воспользоваться этой коммандой");
            }
        }
    }
}
