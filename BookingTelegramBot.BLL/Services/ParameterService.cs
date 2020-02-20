using AutoMapper;
using BookingTelegramBot.BLL.DTO;
using BookingTelegramBot.BLL.Interfaces;
using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.BLL.Services
{
    public class ParameterService : IParameterService
    {
        public ParameterRepo parameterRepo;
        private readonly IMapper mapper;

        public ParameterService(ParameterRepo parameterRepo, IMapper mapper)
        {
            this.parameterRepo = parameterRepo;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ParameterDTO>> GetAll()
        {
            var parameters = await parameterRepo.GetAll();
            var parametersDTO = mapper.Map<IEnumerable<ParameterDTO>>(parameters);
            return parametersDTO;
        }

        public async Task<ParameterDTO> GetParameterById(int parameterId)
        {
            var parameter = await parameterRepo.GetParameterById(parameterId);
            var parameterDTO = mapper.Map<ParameterDTO>(parameter);
            return parameterDTO;
        }

        public void Insert(ParameterDTO parameter)
        {
            parameterRepo.Insert(mapper.Map<Parameter>(parameter));
        }

        public void Update(ParameterDTO parameter)
        {
            parameterRepo.Update(mapper.Map<Parameter>(parameter));
        }

        public void Delete(int parameterId)
        {
            parameterRepo.Delete(parameterId);
        }

        public async Task Save()
        {
            await parameterRepo.Save();
        }
    }
}
