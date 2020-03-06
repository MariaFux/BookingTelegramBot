using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingTelegramBot.BLL.Infrastructure;
using BookingTelegramBot.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BookingTelegramBot.Controllers
{
    [Route("api/message")]
    public class MessageController : Controller
    {
        private readonly MessageService _messageService;

        public MessageController(MessageService messageService)
        {
            _messageService = messageService;
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
            if (update == null) return Ok();

            await _messageService.MessageHandling(update);

            return Ok();
        }
    }
}