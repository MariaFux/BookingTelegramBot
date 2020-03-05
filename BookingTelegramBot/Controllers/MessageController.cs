using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingTelegramBot.BLL.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BookingTelegramBot.Controllers
{
    [Route("api/message")]
    public class MessageController : Controller
    {
        private readonly Bot _bot;

        public MessageController(Bot bot)
        {
            _bot = bot;
            _bot.GetBotClientAsync().Wait();
        }

        [HttpGet]
        [Route("get")]
        public string Get()
        {            
            return "Get";
        }
        
        [HttpPost]
        [Route("postmessage")]
        public async Task<OkResult> PostAsync([FromBody]Update update)
        {
            bool isACommand = false;
            if (update == null) return Ok();

            var commands = _bot.Commands;
            var message = update.Message;
            var botClient = await _bot.GetBotClientAsync();

            foreach (var command in commands)
            {
                if (command.Contains(message))
                {
                    await command.Execute(message, botClient);
                    isACommand = true;
                    break;
                }
            }

            if (message?.Type == MessageType.Text && !isACommand)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, message.Text);
            }

            return Ok();
        }
    }
}