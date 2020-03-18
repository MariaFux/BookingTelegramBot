using AutoMapper;
using BookingTelegramBot.BLL.Mapper;
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
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()), typeof(Startup));
        }

        protected override IHostBuilder CreateHostBuilder(AssemblyName assemblyName) =>
        base.CreateHostBuilder(assemblyName)
            .ConfigureServices(ConfigureServices);
    }
}
