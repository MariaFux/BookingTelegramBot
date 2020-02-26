using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BookingTelegramBot.BLL.DTO;
using BookingTelegramBot.BLL.Services;
using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingTelegramBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserService _userService;
        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("find/{id}")]
        public async Task FindUserASync(int id)
        {
            var user = await _userService.FindByUserIdAsync(id);
            await AuthenticateAsync(user);
        }

        [HttpGet]
        [Route("getuser/{name}")]
        public async Task GetUserAsync(string name)
        {
            var user = await _userService.GetUserAsync(name);
            await AuthenticateAsync(user);
        }

        private async Task AuthenticateAsync(UserDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.TelegramName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.UserRole.ToString())
            };
            
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}