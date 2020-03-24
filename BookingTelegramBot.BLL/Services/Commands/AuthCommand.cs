using BookingTelegramBot.BLL.DTO;
using BookingTelegramBot.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BookingTelegramBot.BLL.Services.Commands
{
    public class AuthCommand : ICommand
    {
        private readonly UserService _userService;

        public AuthCommand(UserService userService)
        {
            _userService = userService;
        }

        public string Name => @"/auth";

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
*Шаблон:* _/free Date Time NumberOfPersons_
`/free 2020-02-18 15:31 5`
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
                answer += "\n`Шаблон:";
                answer += "\n/createroom, Name, Descr, PersonsCount";
                answer += "\n/createroom, Room 1, First, 10`";

                answer += "\n/updateroom - Позволяет изменить существующую комнату";
                answer += "\n_Шаблон:_ _/updateroom, RoomId, Name, Description, NumberOfPersons_";
                answer += "\n`/updateroom, 1, Room 1, First room, 10`";

                answer += "\n/deleteroom - Позволяет удалить существующую комнату";
                answer += "\n_Шаблон:_ _/deleteroom RoomId_";
                answer += "\n`/deleteroom 1`";

                answer += "\n/getallusers - Список всех пользователей";

                answer += "\n/setrole - Позволяет изменить роль пользователя";
                answer += "\n_Шаблон:_ _/setrole UserId RoleId UserTelegramId_";
                answer += "\n`/setrole 1 1 111111111`";

                answer += "\n/createparameter - Позволяет добавить новый параметер";
                answer += "\n_Шаблон:_ _/createparameter ParameterName_";
                answer += "\n`/createparameter Projector`";

                answer += "\n/updateparameter - Позволяет изменить имеющийся параметер";
                answer += "\n_Шаблон:_ _/updateparameter ParameterId ParameterName_";
                answer += "\n`/updateparameter 1 Display`";

                answer += "\n/getallparameters - Список всех параметров";

                answer += "\n/deleteparameter - Позволяет удалить параметер";
                answer += "\n_Шаблон:_ _/deleteparameter ParameterId_";
                answer += "\n`/deleteparameter 1`";

                answer += "\n/allroomsparameters - Список всех комнат с параметрами";

                answer += "\n/addroomsparameters - Позволяет добавить параметры к комнате";
                answer += "\n_Шаблон:_ _/addroomsparameters RoomId ParameterIds_";
                answer += "\n`/addroomsparameters 1 1 2 3 4 5`";

                answer += "\n/roomsparametersdelete - Позволяет убрать параметер из комнаты";
                answer += "\n_Шаблон:_ _/roomsparametersdelete RoomId ParameterId_";
                answer += "\n`/roomsparametersdelete 1 4`";

                await client.SendTextMessageAsync(chatId, answer, ParseMode.Markdown);
            }
            else if (user != null && user.Role.UserRole.ToString() == "user")
            {
                await client.SendTextMessageAsync(chatId, answer);
            }
            else
            {
                var userDTO = new UserDTO() { TelegramId = telegramId, RoleId = 2 };
                _userService.Insert(userDTO);
                await _userService.SaveAsync();
                await client.SendTextMessageAsync(chatId, answer);
            }
        }
    }
}
