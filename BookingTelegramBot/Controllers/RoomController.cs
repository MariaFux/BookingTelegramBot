using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingTelegramBot.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingTelegramBot.Controllers
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
           var room = roomService.GetRoomById(id);
           
            await Response.WriteAsync(room.Name + " Description: " + room.Description + " Another description: " + room.AnotherDescription);
        }

        [Route("all")]
        public async void GetAll()
        {
            var rooms = roomService.GetAllWithParameters();
            
            foreach (var room in rooms)
            {
                await Response.WriteAsync(room.Name + " " + room.Description + " " + room.AnotherDescription + " \n");
                foreach(var param in room.RoomParameters)
                {
                    await Response.WriteAsync(param.Parameter.NameOfParameter + " \n");
                }
            }
                
        }
    }
}