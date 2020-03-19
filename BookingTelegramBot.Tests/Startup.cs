using AutoMapper;
using BookingTelegramBot.BLL.Mapper;
using BookingTelegramBot.DAL.EF;
using BookingTelegramBot.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;

[assembly: TestFramework("BookingTelegramBot.Tests.Startup", "BookingTelegramBot.Tests")]
namespace BookingTelegramBot.Tests
{
    public class Startup : DependencyInjectionTestFramework
    {
        public Startup(IMessageSink messageSink) : base(messageSink)
        {           
        }

        protected void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<RoomRepo>();
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()), typeof(Startup));
            services.AddDbContext<BookingRoomDbContext>(options => options.UseInMemoryDatabase(databaseName: "BookingRoom"));
            SeedData(services);
        }

        protected override IHostBuilder CreateHostBuilder(AssemblyName assemblyName) =>
        base.CreateHostBuilder(assemblyName)
            .ConfigureServices(ConfigureServices);

        private void SeedData(IServiceCollection services)
        {
            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var servicesIn = scope.ServiceProvider;
                var context = servicesIn.GetRequiredService<BookingRoomDbContext>();
                BookingRoomDbContextInitialize.Initialize(servicesIn);
            }
        }
    }
}
