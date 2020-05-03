using AutoMapper;
using BookingTelegramBot.BLL.DTO;
using BookingTelegramBot.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.BLL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<Parameter, ParameterDTO>().ReverseMap();
            CreateMap<UserReservation, UserReservationDTO>().ReverseMap();
            CreateMap<RoomUserReservation, RoomUserReservationDTO>().ReverseMap();
            CreateMap<RoomParameter, RoomParameterDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
}
