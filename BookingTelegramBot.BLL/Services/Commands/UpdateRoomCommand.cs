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
    public class UpdateRoomCommand : ICommand
    {
        private readonly RoomService _roomService;
        private readonly UserService _userService;

        public UpdateRoomCommand(RoomService roomService, UserService userService)
        {
            _roomService = roomService;
            _userService = userService;
        }

        public string Name => @"/updateroom";

        public bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;
            return message.Text.Contains(this.Name);
        }

        public async Task Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;

            var answer = "";

            var telegramId = message.From.Id;
            var user = await _userService.FindByTelegramIdAsync(telegramId);
            if (user != null && user.Role.UserRole.ToString() == "admin")
            {
                string[] roomDescription = message.Text.Split(',');

                var id = Convert.ToInt32(roomDescription[1].Trim());
                var name = roomDescription[2].Trim();
                var description = roomDescription[3].Trim();
                var numberOfPersons = Convert.ToInt32(roomDescription[4].Trim());

                var roomToUpdate = new RoomDTO() { Id = id, Name = name, Description = description, NumberOfPersons = numberOfPersons };

                var rooms = await _roomService.GetAllAsync();
                foreach (var room in rooms)
                {
                    answer += room.Name + " ";
                }

                if (answer.Contains(name))
                {
                    await client.SendTextMessageAsync(chatId, $"Комната {name} уже существует!");
                }
                else if (numberOfPersons <= 0)
                {
                    await client.SendTextMessageAsync(chatId, $"Нельзя обновить комнату для {numberOfPersons} людей");
                }
                else
                {
                    _roomService.Update(roomToUpdate);
                    await _roomService.SaveAsync();

                    await client.SendTextMessageAsync(chatId, $"Изменена комната: {name}");
                }                
            }
            else
            {
                await client.SendTextMessageAsync(chatId, $"Вам не хватает доступа чтобы воспользоваться этой коммандой");
            }
        }
    }
}
