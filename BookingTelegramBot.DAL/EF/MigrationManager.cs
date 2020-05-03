using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingTelegramBot.DAL.EF
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            var serviceScope = host.Services.CreateScope();
            var appContext = serviceScope.ServiceProvider.GetRequiredService<BookingRoomDbContext>();

            Console.WriteLine("Applaing Migrations...");
            appContext.Database.Migrate();
            Console.WriteLine("Done");

            return host;
        }
    }
}
