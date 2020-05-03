using BookingTelegramBot.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BookingTelegramBot.BLL.Services.Commands
{
    public class FreeCommand : ICommand
    {
        private readonly RoomService _roomService;

        public FreeCommand(RoomService roomService)
        {
            _roomService = roomService;
        }

        public string Name => @"/free";        

        public bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;
            return message.Text.Contains(this.Name);
        }

        public async Task Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;

            string[] dateTimeCount = message.Text.Split(',');

            DateTime dateTime = Convert.ToDateTime(dateTimeCount[1].Trim() + " " + dateTimeCount[2].Trim());
            int persons = Convert.ToInt32(dateTimeCount[3].Trim());

            var rooms = await _roomService.GetAllFreeAsync();

            string find = "";
            string answer = "";

            foreach (var room in rooms)
            {
                foreach (var reservation in room.RoomUserReservations)
                {
                    if ((dateTime >= reservation.UserReservation.DateTimeFrom) && (dateTime <= reservation.UserReservation.DateTimeTo))
                    {
                        find = room.Name;
                    }
                }
                if (room.Name != find && persons < room.NumberOfPersons)
                    answer += room.Name + " ";
            }
            await client.SendTextMessageAsync(chatId, $"Подходящие комнаты: {answer}");
        }
    }
}
