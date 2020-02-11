using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingTelegramBot.BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingTelegramBot.Controllerr
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
        private RoomService roomService;

        public RoomController(RoomService roomService)
        {
            this.roomService = roomService;
        }
        
        [Route("{id}")]
        public async void GetRoomById(int id)
        {
           var room = roomService.GetRoomByID(id);
           
            await Response.WriteAsync(room.Name + " Description: " + room.Description + " Another description: " + room.AnotherDescription);
        }
    }
}