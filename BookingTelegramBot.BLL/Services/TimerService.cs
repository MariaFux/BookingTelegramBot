using BookingTelegramBot.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookingTelegramBot.BLL.Services
{
    public class TimerService
    {
        static Timer _timer;
        long interval = 60000;
        static object synclock = new object();
        static bool sentBeforeDay = false;
        static bool sentBeforeTwoHours = false;

        private readonly UserReservationService _userReservationService;
        private readonly Bot _bot;

        public TimerService(UserReservationService userReservationService, Bot bot)
        {
            _userReservationService = userReservationService;
            _bot = bot;
            Initialize();
        }

        public void Initialize()
        {
            _timer = new Timer(new TimerCallback(SendNotification), null, 0, interval);
        }

        private async void SendNotification(object obj)
        {
            var reservations = await _userReservationService.GetAllAsync();
            var botClient = await _bot.GetBotClientAsync();
            lock (synclock)
            {
                var dd = DateTime.Now.ToShortTimeString();
                foreach(var reservation in reservations)
                {
                    var dayBefore = reservation.DateTimeFrom.AddHours(-24);
                    
                    if (dd == dayBefore.ToShortTimeString() && sentBeforeDay == false)
                    {
                        foreach (var room in reservation.RoomUserReservations)
                        {
                            botClient.SendTextMessageAsync(reservation.TelegramId, $"Ждем вас завтра в {room.Room.Name} в {reservation.DateTimeFrom.TimeOfDay}");
                        }
                        sentBeforeDay = true;
                    } 
                    else if (dd != dayBefore.ToShortTimeString())
                    {
                        sentBeforeDay = false;
                    }

                    var twoHourseBefore = reservation.DateTimeFrom.AddHours(-2);
                    if (dd == twoHourseBefore.ToShortTimeString() && sentBeforeTwoHours == false)
                    {
                        foreach (var room in reservation.RoomUserReservations)
                        {
                            botClient.SendTextMessageAsync(reservation.TelegramId, $"Ждем вас сегодня в {room.Room.Name} в {reservation.DateTimeFrom.TimeOfDay}");
                        }
                        sentBeforeTwoHours = true;
                    }
                    else if (dd != twoHourseBefore.ToShortTimeString())
                    {
                        sentBeforeTwoHours = false;
                    }
                }
                
            }
        }
    }
}
