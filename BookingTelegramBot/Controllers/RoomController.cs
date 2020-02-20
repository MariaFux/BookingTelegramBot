using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingTelegramBot.BLL.DTO;
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
        public async Task GetRoomById(int id)
        {
           var room = await roomService.GetRoomById(id);
           
            await Response.WriteAsync(room.Name + " Description: " + room.Description + " Another description: " + room.NumberOfPersons);
        }

        [Route("all")]
        public async Task GetAll()
        {
            var rooms = await roomService.GetAllWithParameters();
            
            foreach (var room in rooms)
            {
                await Response.WriteAsync(room.Name + " " + room.Description + " " + room.NumberOfPersons + " \n");
                foreach(var param in room.RoomParameters)
                {
                    await Response.WriteAsync(param.Parameter.NameOfParameter + " \n");
                }
            }
                
        }

        [Route("free/{count}")]
        public async Task GetAllFree(int count)
        {
            var rooms = await roomService.GetAllFree();
            var dateTime = new DateTime(2020, 2, 18, 15, 31, 0, DateTimeKind.Utc);
            int persons = count;
            string find = "";

            foreach(var room in rooms)
            {
                foreach(var reservation in room.RoomUserReservations)
                {
                    if ((dateTime >= reservation.UserReservation.DateTimeFrom) && (dateTime <= reservation.UserReservation.DateTimeTo))
                    {
                        find = room.Name;
                    }
                }
                if (room.Name != find && persons < room.NumberOfPersons )
                    await Response.WriteAsync(room.Name);
            }
        }

        [Route("insert")]
        public async Task<IActionResult> Insert()
        {
            RoomDTO roomDTO = new RoomDTO() { Name = "Room 4", Description = "Fourth", NumberOfPersons = 20 };
            roomService.Insert(roomDTO);
            await roomService.Save();
            return NoContent();
        }

        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            roomService.Delete(id);
            await roomService.Save();
            return NoContent();
        }
    }
}