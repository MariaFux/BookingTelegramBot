using BookingTelegramBot.BLL.Infrastructure;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookingTelegramBot.BLL.Services
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private Timer _timer;

        private readonly UserReservationService _userReservationService;
        private readonly Bot _bot;

        public TimedHostedService(UserReservationService userReservationService, Bot bot)
        {
            _userReservationService = userReservationService;
            _bot = bot;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(Notification, null, TimeSpan.Zero, TimeSpan.FromSeconds(60));

            return Task.CompletedTask;
        }

        private async void Notification(object state)
        {
            var reservations = await _userReservationService.GetAllAsync();
            var botClient = await _bot.GetBotClientAsync();
            
            var dd = DateTime.Now.ToShortTimeString();
            foreach (var reservation in reservations)
            {
                var dayBefore = reservation.DateTimeFrom.AddHours(-24);
                if (dd == dayBefore.ToShortTimeString())
                {
                    foreach (var room in reservation.RoomUserReservations)
                    {
                        await botClient.SendTextMessageAsync(reservation.TelegramId, $"Ждем вас завтра в {room.Room.Name} в {reservation.DateTimeFrom.TimeOfDay}");
                    }
                }

                var twoHourseBefore = reservation.DateTimeFrom.AddHours(-2);
                if (dd == twoHourseBefore.ToShortTimeString())
                {
                    foreach (var room in reservation.RoomUserReservations)
                    {
                        await botClient.SendTextMessageAsync(reservation.TelegramId, $"Ждем вас сегодня в {room.Room.Name} в {reservation.DateTimeFrom.TimeOfDay}");
                    }
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
