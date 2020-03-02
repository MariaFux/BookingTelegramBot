using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookingTelegramBot.BLL.Infrastructure;
using BookingTelegramBot.BLL.Mapper;
using BookingTelegramBot.BLL.Services;
using BookingTelegramBot.DAL.EF;
using BookingTelegramBot.DAL.Repositories;
using BookingTelegramBot.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BookingTelegramBot
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var ConnectionString = Configuration.GetConnectionString("DbConstr");
            services.AddDbContext<BookingRoomDbContext>(options => options.UseSqlServer(ConnectionString), ServiceLifetime.Transient);
            services.AddTransient<BookingRoomDbContext>();
            services.AddTransient<ParameterRepo>();
            services.AddTransient<RoomRepo>();
            services.AddTransient<UserReservationRepo>();
            //services.AddControllersWithViews();
            services.AddTransient<ParameterService>();
            services.AddTransient<RoomService>();
            services.AddTransient<UserReservationService>();          

            services.AddControllers().AddNewtonsoftJson();

            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()), typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddFile("D:/LogFile.log");

            app.UseLogging();

            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Bot.GetBotClientAsync().Wait();
        }
    }
}
