using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingTelegramBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [Authorize]
        [Route("identify")]
        public IActionResult Identify()
        {
            return Content(User.Identity.Name);
        }

        [Authorize(Roles = "admin, user")]
        [Route("general")]
        public IActionResult GeneralAccess()
        {
            string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            return Content($"Your role: {role}");
        }

        [Authorize(Roles = "admin")]
        [Route("limited")]
        public IActionResult LimitedAccess()
        {
            return Content("Only for admin");
        }
    }
}