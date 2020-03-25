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
    public class MessageController : ControllerBase
    {
        private readonly MessageService _messageService;
        private readonly TimerService _timerService;

        public MessageController(MessageService messageService, TimerService timerService)
        {
            _messageService = messageService;
            _timerService = timerService;
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