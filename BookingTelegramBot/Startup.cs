using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookingTelegramBot.BLL.Infrastructure;
using BookingTelegramBot.BLL.Mapper;
using BookingTelegramBot.BLL.Services;
using BookingTelegramBot.BLL.Services.v2;
using BookingTelegramBot.BLL.Services.Commands;
using BookingTelegramBot.DAL.EF;
using BookingTelegramBot.DAL.Repositories;
using BookingTelegramBot.DAL.Repositories.v2;
using BookingTelegramBot.Middleware;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Telegram.Bot.Types;

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
            services.AddDbContext<BookingRoomDbContext>(options => options.UseSqlServer(ConnectionString), ServiceLifetime.Singleton);

            services.AddTransient<ParameterRepo>();
            services.AddTransient<RoomRepo>();
            services.AddTransient<UserReservationRepo>();
            services.AddTransient<UserRepo>();
            services.AddTransient<RoomParameterRepo>();
            services.AddTransient<RoomUserReservationRepo>();
            services.AddTransient<RoomRepoV2>();
            services.AddTransient<UserRepoV2>();

            services.AddTransient<ParameterService>();
            services.AddTransient<RoomService>();
            services.AddTransient<UserReservationService>();
            services.AddTransient<UserService>();
            services.AddTransient<MessageService>();
            services.AddTransient<RoomParameterService>();
            services.AddTransient<RoomUserReservationService>();
            services.AddTransient<RoomServiceV2>();
            services.AddTransient<UserServiceV2>();

            services.AddControllers().AddNewtonsoftJson();
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()), typeof(Startup));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options => //CookieAuthenticationOptions
               {
                   options.LoginPath = new PathString("/Account/Login");
                   options.AccessDeniedPath = new PathString("/Account/Login");
               });

            services.Configure<BotSettings>(Configuration.GetSection("BotSettings"));

            services.AddSingleton<BotSettings>();
            services.AddSingleton<Bot>();
            services.AddSingleton<AuthCommand>();
            services.AddSingleton<FreeCommand>();
            services.AddSingleton<CreateRoomCommand>();
            services.AddSingleton<UpdateRoomCommand>();
            services.AddSingleton<GetAllRoomsCommand>();
            services.AddSingleton<DeleteRoomCommand>();
            services.AddSingleton<GetAllUsersCommand>();
            services.AddSingleton<SetRoleCommand>();
            services.AddSingleton<CreateParameterCommand>();
            services.AddSingleton<UpdateParameterCommand>();
            services.AddSingleton<DeleteParameterCommand>();
            services.AddSingleton<GetAllParametersCommand>();
            services.AddSingleton<AllRoomsParametersCommand>();
            services.AddSingleton<AddRoomsParametersCommand>();
            services.AddSingleton<DeleteRoomParameterCommand>();
            services.AddSingleton<BookARoomCommand>();
            services.AddSingleton<MyReservationsCommand>();
            services.AddSingleton<CommandsListCommand>();
            services.AddSingleton<CommandsList>();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookingTelegramBot API", Version = "v1" }));

            //services.AddHostedService<TimedHostedService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookingTelegramBot API v1");
                c.RoutePrefix = string.Empty;
            });

            //loggerFactory.AddFile("D:/LogFile.log");
            //app.UseLogging();

            app.UseRouting();            
            app.UseCors();

            app.UseAuth();        
            app.UseAuthorization();            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();                
            });            
        }
    }
}
