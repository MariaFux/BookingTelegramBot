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
    public class MyReservationsCommand : ICommand
    {
        private readonly UserReservationService _userReservationService;

        public MyReservationsCommand(UserReservationService userReservationService)
        {
            _userReservationService = userReservationService;
        }

        public string Name => @"/myreservations";

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

            var answer = "";

            var reservations = await _userReservationService.GetReservationByTelegramIdAsync(telegramId);

            foreach (var reservation in reservations)
            {
                answer += $"\n{reservation.UserName}, {reservation.DateTimeFrom.ToShortDateString()}, с {reservation.DateTimeFrom.TimeOfDay}, до {reservation.DateTimeTo.TimeOfDay}, ";
                foreach (var room in reservation.RoomUserReservations)
                {
                    answer += $"{room.Room.Name} на {room.Room.NumberOfPersons} человек";
                }
                answer += "\n";
            }

            await client.SendTextMessageAsync(chatId, $"Список ваших бронирований:\n {answer}");
        }
    }
}
