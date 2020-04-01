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
    public class BookARoomCommand : ICommand
    {
        private readonly RoomService _roomService;
        private readonly UserReservationService _userReservationService;
        private readonly UserService _userService;

        public BookARoomCommand( RoomService roomService, UserReservationService userReservationService, UserService userService)
        {
            _roomService = roomService;
            _userReservationService = userReservationService;
            _userService = userService;        
        }

        public string Name => @"/bookaroom";

        public bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;
            return message.Text.Contains(this.Name);
        }

        public async Task Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;

            var userName = message.From.FirstName;
            var telegramId = message.From.Id;

            string[] roomUserReservation = message.Text.Split(',');

            var roomName = roomUserReservation[1].Trim();
            DateTime dateTimeFrom = Convert.ToDateTime(roomUserReservation[2].Trim() + " " + roomUserReservation[3].Trim());
            DateTime dateTimeTo = Convert.ToDateTime(roomUserReservation[2].Trim() + " " + roomUserReservation[4].Trim());

            var userReservationToInsert = new UserReservationDTO() { UserName = userName, TelegramId = telegramId, DateTimeFrom = dateTimeFrom, DateTimeTo = dateTimeTo };

            var roomId = _roomService.GetRoomIdByName(roomName);

            userReservationToInsert.RoomUserReservations = new List<RoomUserReservationDTO>
            {
                new RoomUserReservationDTO
                {
                    RoomId = roomId
                }
            };

            _userReservationService.Insert(userReservationToInsert);
            await _userReservationService.SaveAsync();

            await client.SendTextMessageAsync(chatId, $"Вы забронировали {roomName} на {roomUserReservation[2].Trim()} с {roomUserReservation[3].Trim()} до {roomUserReservation[4].Trim()}");           
        }
    }
}
