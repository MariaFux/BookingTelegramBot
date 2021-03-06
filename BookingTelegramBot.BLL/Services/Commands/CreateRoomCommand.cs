﻿using BookingTelegramBot.BLL.DTO;
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
    public class CreateRoomCommand : ICommand
    {
        private readonly RoomService _roomService;
        private readonly UserService _userService;

        public CreateRoomCommand(RoomService roomService, UserService userService)
        {
            _roomService = roomService;
            _userService = userService;
        }

        public string Name => @"/createroom";

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

                var name = roomDescription[1].Trim();
                var description = roomDescription[2].Trim();
                var numberOfPersons = Convert.ToInt32(roomDescription[3].Trim());

                var roomToAdd = new RoomDTO() { Name = name, Description = description, NumberOfPersons = numberOfPersons };

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
                    await client.SendTextMessageAsync(chatId, $"Нельзя создать комнату для {numberOfPersons} людей");
                }
                else
                {
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
            }
            else
            {
                await client.SendTextMessageAsync(chatId, $"Вам не хватает доступа чтобы воспользоваться этой коммандой");
            }        
        }
    }
}
