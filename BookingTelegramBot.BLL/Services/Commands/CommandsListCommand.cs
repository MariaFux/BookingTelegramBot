﻿using BookingTelegramBot.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BookingTelegramBot.BLL.Services.Commands
{
    public class CommandsListCommand : ICommand
    {
        private readonly UserService _userService;

        public CommandsListCommand(UserService userService)
        {
            _userService = userService;
        }

        public string Name => @"/commandslist";

        public bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;
            return message.Text.Contains(this.Name);
        }

        public async Task Execute(Message message, TelegramBotClient client)
        {
            var answer = @"Теперь вы можете использовать полный *перечень команд*:
/free - Позволяет найти свободные комнаты исходя из введенных данных(дата, время, количество человек)
*Шаблон:* _/free, Date, Time, NumberOfPersons_
`/free, 2020-02-18, 15:31, 5`
/getallrooms - Список всех доступных комнат
/bookaroom - Забронировать подходящую комнату
*Шаблон:* _/bookaroom, roomName, Day, TimeFrom, TimeTo_
`/bookaroom, Room 3, 2020-02-18, 15:30, 15:40`
/myreservations - Позволяет просмотреть ваши бронирования";

            var chatId = message.Chat.Id;
            var telegramId = message.From.Id;

            var user = await _userService.FindByTelegramIdAsync(telegramId);

            if (user != null && user.Role.UserRole.ToString() == "admin")
            {
                answer += "\n\n*Admin commands:*";

                answer += "\n/createroom - Позволяет добавить новую комнату";
                answer += "\n*Шаблон:* _/createroom, Name, Descr, PersonsCount_";
                answer += "\n`/createroom, Room 1, First, 10`";

                answer += "\n/updateroom - Позволяет изменить существующую комнату";
                answer += "\n*Шаблон:* _/updateroom, RoomId, Name, Description, NumberOfPersons_";
                answer += "\n`/updateroom, 1, Room 1, First room, 10`";

                answer += "\n/deleteroom - Позволяет удалить существующую комнату";
                answer += "\n*Шаблон:* _/deleteroom, RoomId_";
                answer += "\n`/deleteroom, 1`";

                answer += "\n/getallusers - Список всех пользователей";

                answer += "\n/setrole - Позволяет изменить роль пользователя";
                answer += "\n*Шаблон:* _/setrole, UserId, RoleId, UserTelegramId_";
                answer += "\n`/setrole, 1, 1, 111111111`";

                answer += "\n/createparameter - Позволяет добавить новый параметер";
                answer += "\n*Шаблон:* _/createparameter, ParameterName_";
                answer += "\n`/createparameter, Red pen`";

                answer += "\n/updateparameter - Позволяет изменить имеющийся параметер";
                answer += "\n*Шаблон:* _/updateparameter, ParameterId, ParameterName_";
                answer += "\n`/updateparameter, 1, Display`";

                answer += "\n/getallparameters - Список всех параметров";

                answer += "\n/deleteparameter - Позволяет удалить параметер";
                answer += "\n*Шаблон:* _/deleteparameter, ParameterId_";
                answer += "\n`/deleteparameter, 1`";

                answer += "\n/allroomsparameters - Список всех комнат с параметрами";

                answer += "\n/addroomsparameters - Позволяет добавить параметры к комнате";
                answer += "\n*Шаблон:* _/addroomsparameters, RoomId, ParameterIds_";
                answer += "\n`/addroomsparameters, 1, 1, 2, 3, 4, 5`";

                answer += "\n/roomsparametersdelete - Позволяет убрать параметер из комнаты";
                answer += "\n*Шаблон:* _/roomsparametersdelete, RoomId, ParameterId_";
                answer += "\n`/roomsparametersdelete, 1, 4`";

                await client.SendTextMessageAsync(chatId, answer, ParseMode.Markdown);
            }
            else
            {
                await client.SendTextMessageAsync(chatId, answer);
            }
        }
    }
}
