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
    public class CreateCommand : ICommand
    {
        private readonly RoomService _roomService;
        private readonly UserService _userService;

        public CreateCommand(RoomService roomService, UserService userService)
        {
            _roomService = roomService;
            _userService = userService;
        }

        public string Name => @"/create";

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

                string[] roomDescription = message.Text.Split(',');

                var name = roomDescription[1];
                var description = roomDescription[2];
                var numberOfPersons = Convert.ToInt32(roomDescription[3]);

                var roomToAdd = new RoomDTO() { Name = name, Description = description, NumberOfPersons = numberOfPersons };

                _roomService.Insert(roomToAdd);
                await _roomService.SaveAsync();
                if (numberOfPersons == 1)
                {
                    await client.SendTextMessageAsync(chatId, $"Добавлена комната: {name}, для {numberOfPersons} человека");
                }
                else
                {
                    await client.SendTextMessageAsync(chatId, $"Добавлена комната: {name}, для {numberOfPersons} человек");
                }
            }
            else
            {
                await client.SendTextMessageAsync(chatId, $"Вам не хватает доступа чтобы воспользоваться этой коммандой");
            }
        
        }
    }
}
