using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingTelegramBot.BLL.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace BookingTelegramBot.Controllers
{
    [Route("api/message/update")]
    public class MessageController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "Get";
        }
        
        [HttpPost]
        public async Task<OkResult> Post([FromBody]Update update)
        {
            if (update == null) return Ok();

            var commands = Bot.Commands;
            var message = update.Message;
            var botClient = await Bot.GetBotClientAsync();

            foreach (var command in commands)
            {
                if (command.Contains(message))
                {
                    await command.Execute(message, botClient);
                    break;
                }
            }
            return Ok();
        }
    }
}