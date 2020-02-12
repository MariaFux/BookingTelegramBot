using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingTelegramBot.BusinessLogic.Services;
using BookingTelegramBot.Configurations;
using BookingTelegramBot.Repository;
using BookingTelegramBot.Repository.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddDbContext<BookingRoomDbContext>(options => options.UseSqlServer(ConnectionString));
            services.AddTransient<BookingRoomDbContext>();
            services.AddTransient<ParameterRepo>();
            services.AddTransient<RoomRepo>();
            services.AddTransient<UserReservationRepo>();
            //services.AddControllersWithViews();
            services.AddTransient<ParameterService>();
            services.AddTransient<RoomService>();
            services.AddTransient<UserReservationService>();

            services.AddScoped<IUpdateService, UpdateService>();
            services.AddSingleton<IBotService, BotService>();

            services.Configure<BotConfiguration>(Configuration.GetSection("BotConfiguration"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
