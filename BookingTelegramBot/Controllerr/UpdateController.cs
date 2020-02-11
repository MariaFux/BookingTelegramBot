using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingTelegramBot.BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BookingTelegramBot.Controllerr
{
    [Route("api/update")]
    public class UpdateController : Controller
    {
        private readonly IUpdateService updateService;

        public UpdateController(IUpdateService updateService)
        {
            this.updateService = updateService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            await updateService.EchoAsync(update);
            return Ok();
        }
    }
}