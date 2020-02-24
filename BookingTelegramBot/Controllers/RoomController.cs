﻿using System;
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
        
        [HttpGet]
        [Route("{id}")]
        public async Task GetRoomByIdAsync(int id)
        {
            var room = await roomService.GetRoomByIdAsync(id);           
            await Response.WriteAsync(room.Name + " Description: " + room.Description + " Another description: " + room.NumberOfPersons);
        }

        [HttpGet]
        [Route("all")]
        public async Task GetAllAsync()
        {
            var rooms = await roomService.GetAllWithParametersAsync();
            
            foreach (var room in rooms)
            {
                await Response.WriteAsync(room.Name + " " + room.Description + " " + room.NumberOfPersons + " \n");
                foreach(var param in room.RoomParameters)
                {
                    await Response.WriteAsync(param.Parameter.NameOfParameter + " \n");
                }
            }
                
        }

        [HttpGet]
        [Route("free/{count}")]
        public async Task GetAllFreeAsync(int count)
        {
            var rooms = await roomService.GetAllFreeAsync();
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

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertAsync()
        {
            RoomDTO roomDTO = new RoomDTO() { Name = "Room 4", Description = "Fourth", NumberOfPersons = 20 };
            roomService.Insert(roomDTO);
            await roomService.SaveAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            roomService.Delete(id);
            await roomService.SaveAsync();
            return NoContent();
        }
    }
}