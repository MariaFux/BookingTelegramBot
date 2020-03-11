using BookingTelegramBot.BLL.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace BookingTelegramBot.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly UserService _userService;

        public AuthMiddleware(RequestDelegate next, UserService userService)
        {
            _next = next;
            _userService = userService;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {

            var id = MessageService.Token;
            if (id != 0)
            {
                var user = await _userService.FindByTelegramIdAsync(id);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, user.Role.UserRole.ToString())
                };
                var identity = new ClaimsIdentity(claims);
                httpContext.User.AddIdentity(identity);
            }
            await _next(httpContext);
        }
    }
}
